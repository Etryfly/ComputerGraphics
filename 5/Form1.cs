using _5.Dialogs;
using _5.Projections;
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

namespace _5
{
    public partial class Form1 : Form
    {
        Projection projection = new CentralProjection();

       

        private List<PointF[]> figuresForDraw = new List<PointF[]>();


        public Form1()
        {
            InitializeComponent();
            utils.setFigures(getDefaultObject());
            utils.Resize(20, 20, 20);
        }

        private UtilsFor3D utils = new UtilsFor3D();

        private List<Point3D[]> getDefaultObject()
        {
            List<Point3D[]> result = new List<Point3D[]>();
            Point3D[] poligon1 = new Point3D[3] {new Point3D(-1, 2, 0), new Point3D(2, 0, 0), new Point3D(-1, -2, 0) };
            Point3D[] poligon2 = new Point3D[3] {new Point3D(0, 1, 0), new Point3D(1, 0, 0), new Point3D(0, -1, 0) };
            Point3D[] poligon3 = new Point3D[4] {new Point3D(-1, 2, 0), new Point3D(0, 1, 1),
                new Point3D(1, 0, 1), new Point3D(2, 0, 0) };
            Point3D[] poligon4 = new Point3D[4] {new Point3D(1, 0, 1), new Point3D(2, 0, 0),
                new Point3D(-1, -2, 0), new Point3D(0, -1, 1) };
            Point3D[] poligon5 = new Point3D[4] {new Point3D(-1, -2, 0), new Point3D(0, -1, 1),
                new Point3D(0, 1, 1), new Point3D(-1, 2, 0) };

            result.Add(poligon1);
            result.Add(poligon2);
            result.Add(poligon3);
            result.Add(poligon4);
            result.Add(poligon5);
            return result;
        }

        private PointF[] Centrate(PointF[] points)
        {
            PointF center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            PointF[] result = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i].X = points[i].X + center.X;
                result[i].Y =  -1 * points[i].Y + center.Y;
            }
            return result;
        }
        private void pictureBox_paint(object sender, PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;

          //  PointF center = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
           // g.DrawLine(new Pen(Brushes.Black), new PointF(center.X, 0), new PointF(center.X, center.X * 2));
            // g.DrawLine(new Pen(Brushes.Black), new PointF(0, center.Y), new PointF(center.Y * 4, center.Y));
           


           

            if (projection is CentralProjection)
            {
                CentralProjection proj = projection as CentralProjection;
                figuresForDraw = utils.getCentralProjection(proj.getZ());
            } else if (projection is OrthogonalProjection)
            {
                figuresForDraw = utils.getOrthoProjection();
            } else if (projection is ObliqueProjection)
            {
                ObliqueProjection proj = projection as ObliqueProjection;
                figuresForDraw = utils.getObliqueProjection(proj.getAlpha(), proj.getL());
            }
          //  float[,] pov = new float[1,4] { { 0, 0,1, 1 } };
           // float[,] visabilityMatrix = utils.getVisibilityMatrix(pov);
            Color[] colors = utils.getFiguresColors();
            for (int i = 0; i < figuresForDraw.Count; i++)
            {
              //  if (visabilityMatrix[0,i] >  0)
               // {
                    SolidBrush solidBrush = new SolidBrush(colors[i]);
                    g.DrawPolygon(new Pen(Brushes.Black), Centrate(figuresForDraw[i]));
                    g.FillPolygon(solidBrush, Centrate(figuresForDraw[i]));
               // }
            }
        }

        private void ResizeButtonOnClick(object sender, EventArgs e)
        {
            ResizeForm form = new ResizeForm();
            form.ShowDialog();
            utils.Resize(form.X / 100, form.Y / 100, form.Z / 100);
            pictureBox1.Invalidate();
        }

        private void CentralProjectionOnClick(object sender, EventArgs e)
        {
            
            CentralProjectionForm form = new CentralProjectionForm();
            form.ShowDialog();
            projection = new CentralProjection(form.Z);
            pictureBox1.Invalidate();            
        }

        private void OrthProjectionOnClick(object sender, EventArgs e)
        {
            projection = new OrthogonalProjection();
            pictureBox1.Invalidate();
        }

        private void ObliqueProjectionOnClick(object sender, EventArgs e)
        {
            ObliqueProjectionForm form = new ObliqueProjectionForm();
            form.ShowDialog();
            projection = new ObliqueProjection(form.Alpha, form.L);
            pictureBox1.Invalidate();
        }

        private void MoveOnClick(object sender, EventArgs e)
        {
            MoveForm form = new MoveForm();
            form.ShowDialog();
            utils.Move(form.X, form.Y, form.Z);
            pictureBox1.Invalidate();
        }

        private void yZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.ReflectYZ();
            pictureBox1.Invalidate();
        }

        private void yXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.ReflectYX();
            pictureBox1.Invalidate();
        }

        private void zXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.ReflectZX();
            pictureBox1.Invalidate();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateForm form = new RotateForm();
            form.ShowDialog();
            utils.RotateX(form.Angle);
            pictureBox1.Invalidate();
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateForm form = new RotateForm();
            form.ShowDialog();
            utils.RotateY(form.Angle);
            pictureBox1.Invalidate();
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateForm form = new RotateForm();
            form.ShowDialog();
            utils.RotateZ(form.Angle);
            pictureBox1.Invalidate();
        }

        private void ResetOnClick(object sender, EventArgs e)
        {
            utils.setFigures(getDefaultObject());
            utils.Resize(20, 20, 20);
            pictureBox1.Invalidate();
        }
    }
}
