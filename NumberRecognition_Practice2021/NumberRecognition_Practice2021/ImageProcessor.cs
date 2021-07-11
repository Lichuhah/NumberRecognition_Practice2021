using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberRecognition_Practice2021
{
    static class ImageProcessor
    {
        static public Image ScaleImage(Image source, int width, int height)
        {
            Point[] bgges = FindImageBordes(source);
            source = CropImage(source, bgges);

            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height);  // Очищаем экран
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)  // Исходное изображение меньше целевого
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth / dstheight)  // Пропорции исходного изображения более широкие
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else  // Пропорции исходного изображения более узкие
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }

                return dest;
            }
        }
        static public Image CropImage(Image img, Point[] points)
        {
            Bitmap map = new Bitmap(img);
            int x1 = points[0].X;
            int y1 = points[0].Y;
            int x2 = points[1].X;
            int y2 = points[1].Y;
            int width = x2 - x1 + 1;
            int height = y2 - y1 + 1;

            var result = new Bitmap(width, height);

            for (int i = x1; i <= x2; i++)
                for (int j = y1; j <= y2; j++)
                    result.SetPixel(i - x1, j - y1, map.GetPixel(i, j));

            result.Save(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\testCROP.jpg");
            return result;
        }
        static public double GetDoubleFromColor(Color color)
        {
            double a = Convert.ToDouble(color.R + color.G + color.B) / 765;
            return a;
        }
        static public double[] FromImageToInputs(Image pic)
        {
            pic.Save(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\test.jpg");
            Image outimg = pic;
            if (pic.Width != 10 && pic.Height != 15)
            {
                outimg = ImageProcessor.ScaleImage(pic, 10, 15);
            }
            outimg.Save(@"C:\Users\belov\Desktop\NumberRecognition_Practice2021\test2.jpg");
            Bitmap outmap = new Bitmap(outimg);
            double[] inputs = new double[150];

            for (int i = 0; i < outmap.Height; i++)
            {
                for (int j = 0; j < outmap.Width; j++)
                {
                    double a = GetDoubleFromColor(outmap.GetPixel(j, i));
                    inputs[i * 10 + j] = a;
                }
            }

            return inputs;
        }
        static public Point[] FindImageBordes(Image pic)
        {
            Bitmap img = new Bitmap(pic);
            Point[] borders = new Point[2];
            borders[0] = new Point(0, 0);
            borders[1] = new Point(0, 0);
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    double temp = GetDoubleFromColor(img.GetPixel(j, i));
                    if (temp < 0.8)
                    {
                        borders[0].Y = i;
                        i = pic.Height;
                        j = pic.Width;
                    }
                }
            }

            for (int i = pic.Height - 1; i > 0; i--)
            {
                for (int j = pic.Width - 1; j > 0; j--)
                {
                    double temp =GetDoubleFromColor(img.GetPixel(j, i));
                    if (temp < 0.8)
                    {
                        borders[1].Y = i;
                        i = 0;
                        j = 0;
                    }
                }
            }

            for (int i = 0; i < pic.Width; i++)
            {
                for (int j = 0; j < pic.Height; j++)
                {
                    double temp = GetDoubleFromColor(img.GetPixel(i, j));
                    if (temp < 0.8)
                    {
                        borders[0].X = i;
                        i = pic.Width;
                        j = pic.Height;
                    }
                }
            }

            for (int i = pic.Width - 1; i > 0; i--)
            {
                for (int j = pic.Height - 1; j > 0; j--)
                {
                    double temp = GetDoubleFromColor(img.GetPixel(i, j));
                    if (temp < 0.8)
                    {
                        borders[1].X = i;
                        i = 0;
                        j = 0;
                    }
                }
            }

            return borders;
        }
        static public byte[] GetByteFromImage(Image pic)
        {
            using (var ms = new MemoryStream())
            {
                pic.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        static public Image GetImageFromByte(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
