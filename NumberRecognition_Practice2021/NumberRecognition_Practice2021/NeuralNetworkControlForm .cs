using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace NumberRecognition_Practice2021
{
    public partial class Form1 : Form
    {
        private Network network;
        private Bitmap map = new Bitmap(100, 100);
        private Graphics graphics;
        private Pen pen = new Pen(Color.Black, 20f);
        private bool isMouse = false;
        private ArrayPoints arrayPoints = new ArrayPoints(2);
        private Perceptron p;
        private List<double[]> input = new List<double[]>();
        private List<double[]> output = new List<double[]>();


        public Form1()
        {
            InitializeComponent();
            SetSize();
            
           

            int inputCount = 150;
            int outputCount = 10;
            int[] net_def = new int[] { inputCount,24 ,outputCount };
            p = new Perceptron(net_def);
        }


        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(map);
            graphics.Clear(pictureBox.BackColor);
            pictureBox.Image = map;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
            if (e.Button == MouseButtons.Left)
            {
                pen.Color = Color.Black;
            } else
            {
                pen.Color = Color.White;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouse = false;
            arrayPoints.ResetPoints();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse)
            {
                return;
            }

            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 2)
            {
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        private void btnClearPictureBox_Click(object sender, EventArgs e)
        {
            graphics.Clear(pictureBox.BackColor);
            pictureBox.Image = map;
        }



        private void btnAddData_Click(object sender, EventArgs e)
        {
            double[] inputs = ImageProcessor.FromImageToInputs(pictureBox.Image);
            double[] outputs = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            outputs[Convert.ToInt32(txtAddData.Text)] = 1;
            input.Add(inputs);
            output.Add(outputs);
            Image img = ImageProcessor.ScaleImage(pictureBox.Image, 10, 15);
            LiteWebClient.PostImage(Convert.ToInt32(txtAddData.Text), img , network.Id);
            img.Save(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\test3.jpg");
        }

       
        private void btnTrainNetwork_Click(object sender, EventArgs e)
        {
            int inputCount = 150;
            int outputCount = 10;
            int[] net_def = new int[] { inputCount ,30,outputCount };

            while (!p.Learn(input, output, 0.8, 0.3, 30000, 10000))
            {
                p = new Perceptron(net_def);
            }

            network.Data = Perceptron.GetByteFromPerceptron(p);

            string json = JsonConvert.SerializeObject(network);
            var WebClient = LiteWebClient.GetWebClientForJson();
            string response = WebClient.UploadString("https://localhost:44387/api/Network/" + ((Network)cmbNetworkDelete.SelectedItem).Id, "PUT", json);
        }

        static double normalize(double val, double min, double max)
        {
            return (val - min) / (max - min);
        }
        static double inverseNormalize(double val, double min, double max)
        {
            return val * (max - min) + min;
        }

        private void btnCheckNumber_Click(object sender, EventArgs e)
        {
            double[] inputs = ImageProcessor.FromImageToInputs(pictureBox.Image);
            double[] sal = p.Activate(inputs);

            lblResult.Text = "";
            int max = 0;
            for (int i = 0; i < 10; i++)
            {
                if (sal[max] < sal[i])
                {
                    max = i;
                }
                
            }
            lblResult.Text = max.ToString();
        }

        private void btnCreateNewNetwork_Click(object sender, EventArgs e)
        {
            LiteWebClient.PostNetwork(txtNewNetworkName.Text, Perceptron.GetByteFromPerceptron(p));
        }

        private void cmbNetworkSelection_Click(object sender, EventArgs e)
        {
            var WebClient = LiteWebClient.GetWebClientForJson();
            string json = WebClient.DownloadString("https://localhost:44387/api/Network/GetNames");
            List<Network> things = JsonConvert.DeserializeObject<List<Network>>(json);
            cmbNetworkSelection.DataSource = things;
            cmbNetworkSelection.DisplayMember = "Name";
            cmbNetworkDelete.DataSource = things;
            cmbNetworkDelete.DisplayMember = "Name";             
        }

        private void btnNetworkSelection_Click(object sender, EventArgs e)
        {
            network = LiteWebClient.GetPerceptron((Network)cmbNetworkSelection.SelectedItem);
            p = Perceptron.GetPerceptronFromByte(network.Data);
            btnAddData.Enabled = true;
            btnCheckNumber.Enabled = true;
            btnTrainNetwork.Enabled = true;
            btnDeleteData.Enabled = true;
        }

        private void btnDeleteNetwork_Click(object sender, EventArgs e)
        {
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            string json = WebClient.UploadString("https://localhost:44387/api/Network/" + ((Network)cmbNetworkDelete.SelectedItem).Id, "DELETE", "");
        }

        private void btnLoadDataSet_Click(object sender, EventArgs e)
        {
            var WebClient = LiteWebClient.GetWebClientForJson();
            string json = WebClient.DownloadString("https://localhost:44387/api/DataSet/"+network.Id);
            DataSet dataSets = JsonConvert.DeserializeObject<DataSet>(json);
            dataGridView.DataSource = dataSets.Pictures;

            input.Clear();
            output.Clear();
            for(int i=0; i<dataSets.Pictures.Count; i++)
            {
                Image img = ImageProcessor.GetImageFromByte(dataSets.Pictures[i].Image);
                double[] inputs = ImageProcessor.FromImageToInputs(img);
                double[] outputs = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
                outputs[dataSets.Pictures[i].Value] = 1;
                input.Add(inputs);
                output.Add(outputs);
            }

        }

    }
}
