using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    class Drawer
    {
       
        private PictureBox pictureBox;
        private Graphics graphics;
        const int LINE_SIZE = 2;

        float xScale;
        float yScale;
        PointF center;
       

        public Drawer(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            center = new PointF(pictureBox.Size.Width / 2F, pictureBox.Size.Height / 2F);
        }

        public void DrawAxes(Graphics _graphics, PointF min, PointF max)
        {
            graphics = _graphics;
            xScale = center.X / (Math.Abs(max.X) + 1);
            yScale = center.Y / (Math.Abs(max.Y) + 1);
            graphics.TranslateTransform(center.X, center.Y);
            DrawXAxis(new PointF(-center.X, 0), new PointF(center.X, 0));
            DrawYAxis(new PointF(0, -center.Y), new PointF(0, center.Y));
        }


        private void DrawXAxis(PointF left, PointF right)
        {
            int counter = 1;
            graphics.DrawLine(Pens.Black, left, right);
            for (PointF cent = new PointF(xScale, 0); cent.X < right.X; cent.X += xScale)
            {
                graphics.DrawLine((Pens.Black), new PointF(cent.X, LINE_SIZE), new PointF(cent.X, -LINE_SIZE));
                graphics.DrawString(counter++.ToString(), new Font("Courier New", 6), Brushes.Black,
                    cent.X - 4, 3 * LINE_SIZE);
            }
            counter = -1;
            for (PointF cent = new PointF(-xScale, 0); cent.X > left.X; cent.X -= xScale)
            {
                graphics.DrawLine((Pens.Black), new PointF(cent.X, LINE_SIZE), new PointF(cent.X, -LINE_SIZE));
                graphics.DrawString(counter--.ToString(), new Font("Courier New", 6), Brushes.Black,
                    cent.X - 4, 3 * LINE_SIZE);
            }
        }


        private void DrawYAxis(PointF down, PointF up)
        {
            int counter = -1;

            graphics.DrawLine(Pens.Black, down, up);
            for (PointF cent = new PointF(0, yScale); cent.Y < up.Y; cent.Y += yScale)
            {
                graphics.DrawLine((Pens.Black), new PointF(LINE_SIZE, cent.Y), new PointF(-LINE_SIZE, cent.Y));
                graphics.DrawString(counter--.ToString(), new Font("Courier New", 6), Brushes.Black,
                    3 * LINE_SIZE, cent.Y - 4);
            }
            counter = 1;
            for (PointF cent = new PointF(0, -yScale); cent.Y > down.Y; cent.Y -= yScale)
            {
                graphics.DrawLine((Pens.Black), new PointF(LINE_SIZE, cent.Y), new PointF(-LINE_SIZE, cent.Y));
                graphics.DrawString(counter++.ToString(), new Font("Courier New", 6), Brushes.Black,
                    3 * LINE_SIZE, cent.Y - 4);
            }
        }


        public void DrawPlot(List<PointF> points)
        {
            
            for (int i = 0; i < points.Count; i++)
                points[i] = new PointF(points[i].X * xScale, points[i].Y * -yScale);
            graphics.DrawCurve(Pens.Red, points.ToArray());
        }
    }
}
