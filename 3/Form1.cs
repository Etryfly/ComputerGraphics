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
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
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
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i,j,getMidColorInBoxByRadius(r,ref bitmap, i, j));
                }
            }
            pictureBox1.Image = Image.FromHbitmap(bitmap.GetHbitmap());


        }

        private Color getMidColorInBoxByRadius(int radius, ref Bitmap bitmap, int x, int y)
        {
            Point firstPixel = new Point(clamp(x - radius, 0, x), clamp(y - radius, 0, y));
            Point lastPixel = new Point(clamp(x + radius, x, XMax - 1), clamp(y + radius, y, YMax - 1));
            int r = 0, b=0, g=0,a = 0, count = 0;
            int i = firstPixel.X;
            int j = firstPixel.Y;

            while (j <= lastPixel.Y)
            {
                i = firstPixel.X;
                while (i <= lastPixel.X)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    r += pixel.R;
                    g += pixel.G;
                    b += pixel.B;
                    a += pixel.A;
                    count++;
                    i++;
                }
                j++;
            }

            return Color.FromArgb(a / count, r / count, g / count, b / count);

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
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
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
            Bitmap bitmap = new Bitmap(pictureBox1.Image); //TODO fix later
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
            Bitmap bitmap = new Bitmap(pictureBox1.Image); //TODO fix later
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
