﻿using System;
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
            figures = getStartFigures();
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = 0; j < figures[i].Length; j++)
                {
                    figures[i][j].Y *= -1;
                }
                
            }
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
            for (int i = 0; i < figures.Count; i++)
            {
                e.Graphics.DrawPolygon(new Pen(Brushes.Black),Centrate(figures[i]));
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
    }
}