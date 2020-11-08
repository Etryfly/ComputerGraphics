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

      
        public Form1()
        {
            InitializeComponent();
            utils.setFigures(getDefaultObject());
        }

        private UtilsFor3D utils = new UtilsFor3D();

        private List<Point3D[]> getDefaultObject()
        {
            List<Point3D[]> result = new List<Point3D[]>();
          //  Point3D[] poligon1 = new Point3D[3] {new Point3D(-1, 2, 0), new Point3D(2, 0, 0), new Point3D(-1, -2, 0) };
          //  Point3D[] poligon2 = new Point3D[3] {new Point3D(0, 1, 0), new Point3D(1, 0, 0), new Point3D(0, -1, 0) };
            Point3D[] poligon3 = new Point3D[4] {new Point3D(-1, 2, 0), new Point3D(0, 1, 1),
                new Point3D(1, 0, 1), new Point3D(2, 0, 0) };
            Point3D[] poligon4 = new Point3D[4] {new Point3D(1, 0, 1), new Point3D(2, 0, 0),
                new Point3D(-1, -2, 0), new Point3D(0, -1, 1) };
            Point3D[] poligon5 = new Point3D[4] {new Point3D(-1, -2, 0), new Point3D(0, -1, 1),
                new Point3D(0, 1, 1), new Point3D(-1, 2, 0) };

          //  result.Add(poligon1);
          //  result.Add(poligon2);
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
                result[i].Y =  -1* points[i].Y + center.Y;
            }
            return result;
        }
        private void pictureBox_paint(object sender, PaintEventArgs e)
        {
            utils.setFigures(getDefaultObject());
            Graphics g = e.Graphics;
            utils.Resize(50, 50, 50);
            List<PointF[]> figures = utils.getCentralProjection(50);

            SolidBrush solidBrush = new SolidBrush(
         Color.FromArgb(255, 255, 0, 0));

            foreach (PointF[] points in figures)
            {
                g.DrawPolygon(new Pen(Brushes.Black), Centrate(points));
                //g.FillPolygon(solidBrush, Centrate(points));
            }
        }
    }
}
