using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            center.X = pictureBox1.Size.Width / 2;
            center.Y = pictureBox1.Size.Height / 2;
            Reset();
            /*PointF[] resizedFig1 = Resize(figures[0], 10, 10);
            PointF[] resizedFig2 = Resize(figures[1], 10, 10);
            figures[0] = resizedFig1;
            figures[1] = resizedFig2;*/
            //e.Graphics.DrawPolygon(new Pen(Brushes.Black), Centrate(resizedFig2));
        }
        PointF center = new PointF();

        List<PointF[]> figures;

        public List<PointF[]> getStartFigures()
        {
            List<PointF[]> result = new List<PointF[]>();
            PointF[] figure1 = new PointF[4];
            figure1[0] = new PointF(-20, 20);
            figure1[1] = new PointF(0, 20);
            figure1[2] = new PointF(0, 0);
            figure1[3] = new PointF(-20, 0);
            PointF[] figure2 = new PointF[4];
            figure2[0] = new PointF(0, -10);
            figure2[1] = new PointF(0, 10);
            figure2[2] = new PointF(20, 10);
            figure2[3] = new PointF(20, -10);
            result.Add(figure1);
            result.Add(figure2);
            return result;
        }
      

        private void DrawAxis(Graphics graphics)
        {
            
            graphics.DrawLine(new Pen(Brushes.Black), new PointF(center.X, 0), new PointF(center.X, center.X * 2));
            graphics.DrawLine(new Pen(Brushes.Black), new PointF(0, center.Y), new PointF(center.Y * 4, center.Y ));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            center.X = pictureBox1.Size.Width / 2;
            center.Y = pictureBox1.Size.Height / 2;
            
            DrawAxis(e.Graphics);
            SolidBrush solidBrush = new SolidBrush(
            Color.FromArgb(255, 255, 0, 0));
            
            for (int i = 0; i < figures.Count; i++)
            {
                e.Graphics.DrawPolygon(new Pen(Brushes.Black),Centrate(figures[i]));
                e.Graphics.FillPolygon(solidBrush, Centrate(figures[i]));
            }
           
            
        }

        private PointF Resize(PointF point, float mx, float my)
        {
            float[,] matrix = new float[3, 3] { { mx, 0, 0 }, { 0, my, 0 }, { 0, 0, 1 } };
            float[,] input = new float[1, 3] { { point.X, point.Y, 1 } };
            float[,] result = Multiply(input, matrix);
            return new PointF(result[0,0], result[0,1]);
        }

     

        private PointF[] Resize(PointF[] points, float mx, float my)
        {
            PointF[] result = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = Resize(points[i], mx, my);
            }

            return result;
        }

        private PointF Move(PointF point, float x, float y)
        {
            float[,] matrix = new float[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { x, y, 1 } };
            float[,] input = new float[1, 3] { { point.X, point.Y, 1 } };
            float[,] result = Multiply(input, matrix);
            return new PointF(result[0, 0], result[0, 1]);
        }



        private PointF[] Move(PointF[] points, float mx, float my)
        {
            PointF[] result = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = Move(points[i], mx, my);
            }

            return result;
        }

        private PointF Reflect(PointF point, float alpha)
        {
            float cos = (float)Math.Cos(2 * alpha);
            float sin = (float)Math.Sin(2 * alpha);
            float[,] matrix = new float[3, 3] { {cos , sin, 0 }, { sin, -cos, 0 }, { 0, 0, 1 } };
            float[,] input = new float[1, 3] { { point.X, point.Y, 1 } };
            float[,] result = Multiply(input, matrix);
            return new PointF(result[0, 0], result[0, 1]);
        }



        private PointF[] Reflect(PointF[] points, float alpha)
        {
            PointF[] result = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = Reflect(points[i], alpha);
            }

            return result;
        }

        private PointF Rotate(PointF point, float alpha)
        {
            float cos = (float)Math.Cos( alpha);
            float sin = (float)Math.Sin( alpha);
            float[,] matrix = new float[3, 3] { { cos, sin, 0 }, { -sin, cos, 0 }, { 0, 0, 1 } };
            float[,] input = new float[1, 3] { { point.X, point.Y, 1 } };
            float[,] result = Multiply(input, matrix);
            return new PointF(result[0, 0], result[0, 1]);
        }



        private PointF[] Rotate(PointF[] points, float alpha)
        {
            PointF[] result = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                result[i] = Rotate(points[i], alpha);
            }

            return result;
        }

        private PointF[] Centrate(PointF[] points)
        {
            PointF[] pointsClone = (PointF[])points.Clone();
            for (int i = 0; i < points.Length; i++)
            {
                pointsClone[i].X += center.X;
                pointsClone[i].Y += center.Y;
                
            }
            return pointsClone;
        }


      
        private float[,] Multiply(float[,] A, float[,] B)
        {
            if (A.GetLength(1) != B.GetLength(0) ) {
                throw new ArithmeticException();
            }
            float[,] result = new float[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return result;
        }

        private void resizeMenuItem_Click(object sender, EventArgs e)
        {
            ResizeForm form = new ResizeForm();
            form.ShowDialog();
            float X = form.X / 100;
            float Y = form.Y / 100;

            for (int i = 0; i < figures.Count; i++)
            {
                PointF[] resizedFig = Resize(figures[i], X, Y);
                //resizedFig = Centrate(resizedFig);
                figures[i] = resizedFig;
                
            }

            pictureBox1.Invalidate();
           
           
        }

       

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MoveForm form = new MoveForm();
            form.ShowDialog();
            float X = form.X ;
            float Y = form.Y * (-1) ;

            for (int i = 0; i < figures.Count; i++)
            {
                PointF[] movedFig = Move(figures[i], X, Y);
                //resizedFig = Centrate(resizedFig);
                figures[i] = movedFig;

            }

            pictureBox1.Invalidate();
        }

        private void XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float alpha = 0;

            for (int i = 0; i < figures.Count; i++)
            {
                PointF[] movedFig = Reflect(figures[i], alpha);
                //resizedFig = Centrate(resizedFig);
                figures[i] = movedFig;

            }

            pictureBox1.Invalidate();
        }

        private void YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float alpha = (float) Math.PI / 2;

            for (int i = 0; i < figures.Count; i++)
            {
                PointF[] movedFig = Reflect(figures[i], alpha);
                //resizedFig = Centrate(resizedFig);
                figures[i] = movedFig;

            }

            pictureBox1.Invalidate();
        }

        private void XYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float alpha = (float) -Math.PI / 4;

            for (int i = 0; i < figures.Count; i++)
            {
                PointF[] movedFig = Reflect(figures[i], alpha);
                //resizedFig = Centrate(resizedFig);
                figures[i] = movedFig;

            }

            pictureBox1.Invalidate();
        }

        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rotate form = new Rotate();
            form.ShowDialog();
            float alpha = (float)((form.Phi * Math.PI) / 180);

            for (int i = 0; i < figures.Count; i++)
            {
                PointF[] movedFig = Rotate(figures[i], alpha);
                //resizedFig = Centrate(resizedFig);
                figures[i] = movedFig;

            }

            pictureBox1.Invalidate();
        }

        private void PointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotatePointForm form = new RotatePointForm();
            form.ShowDialog();
            float alpha = (float)((form.Angle * Math.PI) / 180);
            float X = form.X;
            float Y = form.Y;

            for (int i = 0; i < figures.Count; i++)
            {
                PointF[] movedFig = Move(figures[i], -X, -Y);
                //resizedFig = Centrate(resizedFig);
                figures[i] = Move(Rotate(movedFig, alpha), X,Y);

            }

            pictureBox1.Invalidate();
        }

        private void Reset()
        {
            figures = getStartFigures();
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = 0; j < figures[i].Length; j++)
                {
                    figures[i][j].Y *= -1;
                }

            }
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
            pictureBox1.Invalidate();
        }
    }
}
