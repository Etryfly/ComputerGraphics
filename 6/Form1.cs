using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            float aX = (float)(30 * Math.PI / 180);
            float aZ = (float)(185 * Math.PI / 180);
            utils.RotateZ(aZ);
           // utils.RotateY(aX);
            utils.RotateX(aX);
            

            Point center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

            List<Point[]> curvesProj;
            if (!hide);
           
            Pen pen = new Pen(Color.Black);
          

            switch (option)
            {
                case 0:
                    {
                        curvesProj = utils.getXZFiguresProj();
                        for (int i = 0; i < curvesProj.Count; i++)
                        {
                            for (int j = 0; j < curvesProj[i].Length - 1; j++)
                            {
                                e.Graphics.DrawLine(pen, Centrate(curvesProj[i][j]), Centrate(curvesProj[i][j + 1]));

                            }

                        }
                    }
                    break;

                case 1:
                    {
                        curvesProj = utils.getProjWithRemovedLines(e.Graphics, center.X, center.Y);
                        for (int i = 0; i < curvesProj.Count; i++)
                        {
                            for (int j = 0; j < curvesProj[i].Length - 1; j++)
                            {
                                e.Graphics.DrawLine(pen, Centrate(curvesProj[i][j]), Centrate(curvesProj[i][j + 1]));

                            }

                        }
                    }
                    break;


                case 2:
                    curvesProj = utils.getXZFiguresProj();
                    for (int i = 0; i < curvesProj.Count; i++)
                    {
                        for (int j = 0; j < curvesProj[i].Length - 1; j++)
                        {
                            e.Graphics.DrawLine(pen, Centrate(curvesProj[i][j]), Centrate(curvesProj[i][j + 1]));

                        }

                    }

                   
                    for (int i = 0; i < curvesProj.Count - 1; i++)
                    {
                        for (int j = 0; j < curvesProj[i].Length; j++)
                        {
                            e.Graphics.DrawLine(pen, Centrate(curvesProj[i][j]), Centrate(curvesProj[i + 1][j]));

                        }

                    }

                    break;

 
                case 3:
                    {
                        curvesProj = utils.getXZFiguresProj();
                        List<Point3D[]> curves = utils.getFigures();
                        for (int i = curvesProj.Count - 2; i >= 0; i--)
                        {
                            for (int j = curvesProj[i].Length - 3; j >= 0 ; j--)
                            {
                                Point3D A = curves[i][j];
                                Point3D B = curves[i + 1][j];
                                Point3D C = curves[i][j + 1];

                                float vx1 = A.X - B.X;
                                float vy1 = A.Y - B.Y;
                                float vz1 = A.Z - B.Z;
                                float vx2 = B.X - C.X;
                                float vy2 = B.Y - C.Y;
                                float vz2 = B.Z - C.Z;

                                Point3D N = new Point3D();
                                N.X = vy1 * vz2 - vz1 * vy2;
                                N.Y = vz1 * vx2 - vx1 * vz2;
                                N.Z = vx1 * vy2 - vy1 * vx2;

                                float[] pov = new float[3];
                                pov[0] = 0.2F;
                                pov[1] = -0.1F;
                                pov[2] = 0.8F;
                                float cosAlpha = (float)((pov[0] * N.X + pov[1] * N.Y + pov[2] * N.Z) /
                                    (Math.Sqrt(N.X * N.X + N.Y + N.Y + N.Z * N.Z) * Math.Sqrt(pov[0] * pov[0] + pov[1] * pov[1] + 
                                    pov[2] * pov[2])));
                                float alpha = (float)Math.Acos(cosAlpha);
                                int c = (int)Math.Abs(255 * Math.Sin(alpha));
                                if (c < 0) c = 0;
                                if (c > 255) c = 255;
                                Pen p = new Pen(Color.FromArgb((int)(c * 0.5F), (int)(c * 0.3F), 50,255));

                                Point[] polygon = new Point[3];
                                 polygon[0] = Centrate(curvesProj[i][j]);
                                  polygon[1] = Centrate(curvesProj[i + 1][j]);
                                 polygon[2] = Centrate(curvesProj[i][j+2]);
                                
                                e.Graphics.DrawPolygon(p, polygon);

                            }

                        }

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
