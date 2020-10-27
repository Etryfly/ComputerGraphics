using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3
{
    public partial class Form1 : Form
    {
        //public File file;
        string fileContent = string.Empty;
        string filePath = string.Empty;
        int XMax;
        int YMax;
        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    pictureBox1.Image = Image.FromFile(filePath);
                    XMax = pictureBox1.Image.Width;
                    YMax = pictureBox1.Image.Height;
                }
            }
        }

            private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
         
        }

        private void BlurButton_Click(object sender, EventArgs e)
        {

            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            int r = (int)radiusUpDown.Value;
            for (int i =0; i < bitmap.Width; i++)
            {
                for (int j =0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i,j,getMidColorInBoxByRadius(r,ref bitmap, i, j));
                }
            }
            pictureBox1.Image = Image.FromHbitmap(bitmap.GetHbitmap());


        }

        private float matrixElementsMultiply(float[,] a, float[,] b)
        {
            float result = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(0); j++)
                {
                    result += a[i, j] * b[i, j];
                }
            }



            return result;
        }

        private Color getMidColorInBoxByRadius(int radius, ref Bitmap bitmap, int x, int y)
        {
            int corrRadius = 2 * radius + 1;
            float[,] core = new float[corrRadius, corrRadius];
            for (int k = 0; k < corrRadius; k++)
            {
                for (int f = 0; f < corrRadius; f++)
                {
                    core[k, f] = 1f / (corrRadius * corrRadius);
                }
            }
            
            
            float[,] R = new float[corrRadius, corrRadius];
            float[,] G = new float[corrRadius, corrRadius];
            float[,] B = new float[corrRadius, corrRadius];
            float[,] A = new float[corrRadius, corrRadius];

            Point firstPixel = new Point(clamp(x - radius, 0, x), clamp(y - radius, 0, y));
            Point lastPixel = new Point(clamp(x + radius, x, XMax - 1), clamp(y + radius, y, YMax - 1) );
            
            int i = firstPixel.X;
            int j = firstPixel.Y;

            while (j <= lastPixel.Y )
            {
                i = firstPixel.X;
                while (i <= lastPixel.X)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    R[i - firstPixel.X, j - firstPixel.Y] = pixel.R;
                    G[i - firstPixel.X, j - firstPixel.Y] = pixel.G;
                    B[i - firstPixel.X, j - firstPixel.Y] = pixel.B;
                    A[i - firstPixel.X, j - firstPixel.Y] = pixel.A;
                    i++;
                }
                j++;
            }
            int r =(int) matrixElementsMultiply(R, core);
            int g =(int) matrixElementsMultiply(G, core);
            int b =(int) matrixElementsMultiply(B, core);
            int a =(int) matrixElementsMultiply(A, core);
            r = clamp(r, 0, 255);
            g = clamp(g, 0, 255);
            b = clamp(b, 0, 255);
            a = clamp(a, 0, 255);
            return Color.FromArgb(a,r,g,b);

        }

        private int clamp(int coord, int min, int max)
        {
            if (coord < min) return min;
            if (coord > max) return max;
            return coord;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image); //TODO fix later
            int r = (int)radiusUpDown.Value;
            for (int i =0; i < bitmap.Width; i++)
            {
                for (int j =0; j < bitmap.Height ; j++)
                {
                    bitmap.SetPixel(i, j, getMidColorInBoxByRadius(r, ref bitmap, i, j));
                }
            }
            pictureBox1.Image = Image.FromHbitmap(bitmap.GetHbitmap());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private Color BrightnessChange(int n, Color source)
        {
          

            int R = setCorrect(source.R + n * 128 / 100);
            int G = setCorrect(source.G + n * 128 / 100);
            int B = setCorrect(source.B + n * 128 / 100);
            return Color.FromArgb(source.A, R, G, B);

        }

        private void brightnessButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            int n = (int)nUpDown.Value;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, BrightnessChange(n, bitmap.GetPixel(i,j)));
                }
            }
            pictureBox1.Image = Image.FromHbitmap(bitmap.GetHbitmap());
        }

        private void contrastButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image); 
            int n = (int)nUpDown.Value;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, ContrastIncrease(n, bitmap.GetPixel(i, j)));
                }
            }
            pictureBox1.Image = Image.FromHbitmap(bitmap.GetHbitmap());
        }

        private int setCorrect(int value)
        {
            if (value > 255) return 255;
            if (value < 0) return 0;
            return value;
        }

        private Color ContrastIncrease(int n, Color source)
        {
            

            int R = setCorrect((source.R * 100 - 128 * n) / (100 - n));
            int G= setCorrect((source.G * 100 - 128 * n) / (100 - n));
            int B = setCorrect((source.B * 100 - 128 * n) / (100 - n));
           
            return Color.FromArgb(source.A, R, G, B);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {

                   
                    System.IO.FileStream fs =
           (System.IO.FileStream)saveFileDialog.OpenFile();
                  
                 
                    pictureBox1.Image.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Jpeg);
                            
                    }
            }
        }
    }
}
