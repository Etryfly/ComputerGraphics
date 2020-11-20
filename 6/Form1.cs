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

        bool axis = false;

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
            float aX = (float)(33 * Math.PI / 180);
            float aZ = (float)(33 * Math.PI / 180);
            utils.RotateZ(aZ);
            utils.RotateX(aX);
            

            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

            List<Point[]> curves;
            if (!hide);
           
            Pen pen = new Pen(Color.Black);
          

            switch (option)
            {
                case 0:
                    {
                        curves = utils.getXZFiguresProj();
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


                case 2:
                    curves = utils.getXZFiguresProj();
                    for (int i = 0; i < curves.Count; i++)
                    {
                        for (int j = 0; j < curves[i].Length - 1; j++)
                        {
                            e.Graphics.DrawLine(pen, Centrate(curves[i][j]), Centrate(curves[i][j + 1]));

                        }

                    }

                   
                    for (int i = 0; i < curves.Count - 1; i++)
                    {
                        for (int j = 0; j < curves[i].Length; j++)
                        {
                            e.Graphics.DrawLine(pen, Centrate(curves[i][j]), Centrate(curves[i + 1][j]));

                        }

                    }

                    break;


                case 3:
                    {
                        utils.plotWithHor(center, e.Graphics, minX, minY, maxX, maxY, count, aX, aZ);

                    }
                    break;
            }

            if (axis)
            {
                List<Point[]> axis = utils.getXZAxisProj();
                for (int i = 0; i < axis.Count; i++)
                {
                    for (int j = 0; j < axis[i].Length - 1; j++)
                    {
                        e.Graphics.DrawLine(pen, Centrate(axis[i][j]), Centrate(axis[i][j+1]));

                    }

                }
            }
           

           
        }

       

        private Point Centrate(Point p)
        {
            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            return new Point(p.X + center.X, p.Y + center.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (axisCheckBox.Checked) axis = true;
            else axis = false;

            count = int.Parse(countTextBox.Text);
            minX = int.Parse(MinXText.Text);
            minY = int.Parse(MinYText.Text);
            maxY = int.Parse(MaxYText.Text);
            maxX = int.Parse(MaxXText.Text);

            pictureBox1.Invalidate();
        }
    }
}
