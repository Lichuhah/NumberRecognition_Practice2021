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
using System.Threading;
using System.Runtime.CompilerServices;

namespace NumberRecognition_Practice2021
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            SetSize();
            
           

            int inputCount = 150;
            int outputCount = 10;
            int[] net_def = new int[] { inputCount,24 ,outputCount };
            p = new Perceptron(net_def);
        }


        //рисование
        private Bitmap map = new Bitmap(100, 100);
        private Graphics graphics;
        private Pen pen = new Pen(Color.Black, 20f);
        private bool isMouse = false;
        private ArrayPoints arrayPoints = new ArrayPoints(2);

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
            }
            else
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
            LiteWebClient.PostImage(Convert.ToInt32(txtAddData.Text), img, network.Id);
            img.Save(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\test3.jpg");
        }

        //работа с сетями
        private Network network;
        private Perceptron p;
        private List<double[]> input = new List<double[]>();
        private List<double[]> output = new List<double[]>();

        private void btnCreateNewNetwork_Click(object sender, EventArgs e)
        {
            try
            {
                String[] ss = textBox1.Text.Split(',');
                int n = ss.Count();
                int[] net_def = new int[n + 1];
                net_def[0] = 150;
                for (int i = 1; i < n + 1; i++)
                {
                    net_def[i] = int.Parse(ss[i - 1]);
                }
                p = new Perceptron(net_def);
                LiteWebClient.PostNetwork(txtNewNetworkName.Text, Perceptron.GetByteFromPerceptron(p));
            }
            catch
            {
                MessageBox.Show("Некорректная запись");
            }
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
            btnNetworkSelection.Enabled = true;
            btnDeleteNetwork.Enabled = true;
        }

        private void btnNetworkSelection_Click(object sender, EventArgs e)
        {
            network = LiteWebClient.GetPerceptron((Network)cmbNetworkSelection.SelectedItem);
            p = Perceptron.GetPerceptronFromByte(network.Data);

            btnCheckNumber.Enabled = true;
            btnLoadDataSet.Enabled = true;
        }

        private void btnDeleteNetwork_Click(object sender, EventArgs e)
        {
            var WebClient = LiteWebClient.GetWebClientForJson();
            string json = WebClient.UploadString("https://localhost:44387/api/Network/" + ((Network)cmbNetworkDelete.SelectedItem).Id, "DELETE", "");
        }


        //работа с датасетами
        private void btnLoadDataSet_Click(object sender, EventArgs e)
        {
            var WebClient = LiteWebClient.GetWebClientForJson();
            string json = WebClient.DownloadString("https://localhost:44387/api/DataSet/" + network.Id);
            DataSet dataSets = JsonConvert.DeserializeObject<DataSet>(json);
            dataGridView.DataSource = dataSets.Pictures;

            input.Clear();
            output.Clear();
            for (int i = 0; i < dataSets.Pictures.Count; i++)
            {
                Image img = ImageProcessor.GetImageFromByte(dataSets.Pictures[i].Image);
                double[] inputs = ImageProcessor.FromImageToInputs(img);
                double[] outputs = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                outputs[dataSets.Pictures[i].Value] = 1;
                input.Add(inputs);
                output.Add(outputs);
            }

            btnAddData.Enabled = true;
            btnDeleteData.Enabled = true;
            btnTrainNetwork.Enabled = true;
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            var WebClient = LiteWebClient.GetWebClientForJson();
            string json = WebClient.UploadString("https://localhost:44387/api/Dataset/" + numIdDeletePic.Value, "DELETE", "");
            Console.WriteLine(json);
        }

        //тренировка и распознание чисел
        private BackgroundWorker bw;
        object isNotStop;

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
        private void btnTrainNetwork_Click(object sender, EventArgs e)
        {
            btnTrainNetwork.Enabled = false;
            btnStopTraining.Enabled = true;
            int inputCount = 150;
            int outputCount = 10;
            int[] net_def = new int[] { inputCount ,30,outputCount };

            bw = new BackgroundWorker { WorkerSupportsCancellation = true };
            bw.DoWork += (obj, args) =>
            {
                BackgroundWorker lbw = (BackgroundWorker)obj;
                isNotStop = true;
                while (!p.Learn(ref isNotStop, input, output, (double)numAlpha.Value, (double)numError.Value, (int)numIterations.Value, 10000))
                {
                p = new Perceptron(net_def);
                }
            };
            bw.RunWorkerAsync();
            network.Data = Perceptron.GetByteFromPerceptron(p);

            string json = JsonConvert.SerializeObject(network);
            var WebClient = LiteWebClient.GetWebClientForJson();
            string response = WebClient.UploadString("https://localhost:44387/api/Network/" + ((Network)cmbNetworkDelete.SelectedItem).Id, "PUT", json);
        }
        private void btnStopTraining_Click(object sender, EventArgs e)
        {
            if (bw != null && bw.IsBusy && !bw.CancellationPending)
            {
                bw.CancelAsync();
                isNotStop = false;
                btnStopTraining.Enabled = false;
                btnTrainNetwork.Enabled = true;
            }
        }

        
    }
}
