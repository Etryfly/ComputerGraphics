using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool xLines = true;
        bool yLines = false;

        int minX = -200;
        int maxX = 200;
        int minY = -200;
        int maxY = 200;

        int count = 60;

        bool hide = false;

        private void pictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            int option = comboBox1.SelectedIndex;
            Utils3D utils = new Utils3D();
            utils.Init(minX, minY, maxX, maxY,count);
           // utils.RotateZ((float)(30 *Math.PI / 180));
           // utils.RotateX((float)(30 *Math.PI / 180));
            // utils.plotWithRemove(e.Graphics);
            //utils.RotateY(30);

            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

            List<Point[]> curves;
            if (!hide);
           
            Pen pen = new Pen(Color.Black);
          

            switch (option)
            {
                case 0:
                    {
                        curves = utils.getXZProj();
                        for (int i = 0; i < curves.Count; i++)
                        {
                            for (int j = 0; j < curves[i].Length - 1; j++)
                            {
                                e.Graphics.DrawLine(pen, Centrate(curves[i][j]), Centrate(curves[i][j + 1]));

                            }

                        }
                    }
                    break;

                case 1:
                    {
                        curves = utils.getProjWithRemovedLines(e.Graphics, center.X, center.Y);
                        for (int i = 0; i < curves.Count; i++)
                        {
                            for (int j = 0; j < curves[i].Length - 1; j++)
                            {
                                e.Graphics.DrawLine(pen, Centrate(curves[i][j]), Centrate(curves[i][j + 1]));

                            }

                        }
                    }
                    break;

            }
           

           
        }

       

        private Point Centrate(Point p)
        {
            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            return new Point(p.X + center.X, p.Y + center.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            count = int.Parse(countTextBox.Text);
            minX = int.Parse(MinXText.Text);
            minY = int.Parse(MinYText.Text);
            maxY = int.Parse(MaxYText.Text);
            maxX = int.Parse(MaxXText.Text);

            pictureBox1.Invalidate();
        }
    }
}
