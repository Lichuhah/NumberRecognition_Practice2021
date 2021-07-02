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
        public Form1()
        {
            InitializeComponent();
            SetSize();
            graphics.Clear(pictureBox.BackColor);
            pictureBox.Image = map;
        }



        private bool isMouse = false;
        private ArrayPoints arrayPoints = new ArrayPoints(2);

        Bitmap map = new Bitmap(100, 100);
        Graphics graphics;
        Pen pen = new Pen(Color.Black, 20f);

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(map);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;
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


        Perceptron p;
        List<double[]> input = new List<double[]>();
        List<double[]> output = new List<double[]>();
        private void btnAddData_Click(object sender, EventArgs e)
        {
            double[] inputs = ImageProcessor.FromImageToInputs(pictureBox.Image);
            double[] outputs = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            outputs[Convert.ToInt32(txtAddData.Text)] = 1;
            input.Add(inputs);
            output.Add(outputs);

            Picture picture = new Picture();
            picture.Value = Convert.ToInt32(txtAddData.Text);
            using(var ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                picture.Image = ms.ToArray();
            }


            //var WebClient = new WebClient();
            //WebClient.Encoding = Encoding.UTF8;
            //string url = "https://localhost:44387/api/Network/" + cmbNetworkSelection.Text;
            //string json = WebClient.DownloadString(url);
            //Network network = JsonConvert.DeserializeObject<Network>(json);
            string json = JsonConvert.SerializeObject(picture);
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            WebClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = WebClient.UploadString("https://localhost:44387/api/DataSet/"+network.Id, json);
        }

        Network network;
        private void btnTrainNetwork_Click(object sender, EventArgs e)
        {
            int inputCount = 150;
            int outputCount = 9;
            int[] net_def = new int[] { inputCount, 80, outputCount };
            p = new Perceptron(net_def);

            while (!p.Learn(input, output, 0.3, 0.1, 20000, 10000))
            {
                p = new Perceptron(net_def);
            }


            network = new Network();
            network.Name = cmbNetworkSelection.Text;
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, p);
                network.Data = ms.ToArray();
            }
            string json = JsonConvert.SerializeObject(network);
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            WebClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = WebClient.UploadString("https://localhost:44387/api/Network/" + 0, "PUT", json);
            // p.save_net(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\test.bin");
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
            for (int i = 0; i < 9; i++)
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
            Network network = new Network();
            network.Name = txtNewNetworkName.Text;
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, p);
                network.Data = ms.ToArray();
            }
            string json = JsonConvert.SerializeObject(network);
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            WebClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = WebClient.UploadString("https://localhost:44387/api/Network", json);
        }

        private void cmbNetworkSelection_Click(object sender, EventArgs e)
        {
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            string json = WebClient.DownloadString("https://localhost:44387/api/Network");
            List<Network> things = JsonConvert.DeserializeObject<List<Network>>(json);
            cmbNetworkSelection.DataSource = things;
            cmbNetworkSelection.DisplayMember = "Name";
            cmbNetworkDelete.DataSource = things;
            cmbNetworkDelete.DisplayMember = "Name";             
        }

        private void btnNetworkSelection_Click(object sender, EventArgs e)
        {
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            string url = "https://localhost:44387/api/Network/" + cmbNetworkSelection.Text;
            string json = WebClient.DownloadString(url);
            network = JsonConvert.DeserializeObject<Network>(json);

            byte[] data = network.Data;
            using (MemoryStream ms = new MemoryStream(data))
            {
                var formatter = new BinaryFormatter();
                ms.Seek(0, SeekOrigin.Begin);
                p = (Perceptron)formatter.Deserialize(ms);
            }
        }

        private void btnDeleteNetwork_Click(object sender, EventArgs e)
        {
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            string json = WebClient.UploadString("https://localhost:44387/api/Network/" + cmbNetworkDelete.Text, "DELETE", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var WebClient = new WebClient();
            WebClient.Encoding = Encoding.UTF8;
            string json = WebClient.DownloadString("https://localhost:44387/api/DataSet/"+network.Id);
            DataSet things = JsonConvert.DeserializeObject<DataSet>(json);
            dataGridView.DataSource = things.Pictures;
        }
    }
}
