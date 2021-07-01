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



        List<double[]> input = new List<double[]>();
        List<double[]> output = new List<double[]>();
        private void btnAddData_Click(object sender, EventArgs e)
        {
            pictureBox.Image.Save(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\test.jpg");
            Image outimg = ImageProcessor.ScaleImage(pictureBox.Image, 10, 15);
            outimg.Save(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\test2.jpg");
            Bitmap outmap = new Bitmap(outimg);
            double[] inputs = new double[150];
            double[] outputs = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < outmap.Height; i++)
            {
                for (int j = 0; j < outmap.Width; j++)
                {
                    Color color = outmap.GetPixel(j, i);
                    double a = Convert.ToDouble(color.R + color.G + color.B) / 765;
                    inputs[i * 10 + j] = a;
                }
            }
           // outputs[0] = Convert.ToDouble(txtAddData.Text) / 10;
            outputs[Convert.ToInt32(txtAddData.Text)] = 1;
            input.Add(inputs);
            output.Add(outputs);
        }
    }
}
