using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }

        
        private void btnTrainNetwork_Click(object sender, EventArgs e)
        {
            int inputCount = 150;
            int outputCount = 9;
            int[] net_def = new int[] { inputCount, 80, outputCount };
            p = new Perceptron(net_def);

            while (!p.Learn(input, output, 0.3, 0.1, 2000, 10000))
            {
                p = new Perceptron(net_def);
            }

            p.save_net(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\test.bin");
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
    }
}
