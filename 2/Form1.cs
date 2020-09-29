using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        Drawer drawer;
        private const float A = 1.5F;
        private const float x0 = 0;
        private const float eps = 0.01F;

        List<PointF> pointsList = new List<PointF>();

        public Form1()
        {
            InitializeComponent();
        }

        private void formulaButton_Click(object sender, EventArgs e)
        {
            pointsList.Clear();
            float left = getLeftX();
            if (left < x0) left = x0;
            for (float i = left  ; i < getRightX(); i += eps)
            {
                double y = formula(i);
                if (!Double.IsNaN(y) )
                    pointsList.Add(new PointF(i, Convert.ToSingle(y )));
            }

            pictureBox1.Invalidate();
            
        }

        private float getLeftX()
        {
            return Convert.ToSingle(leftXUpDown.Value);
        }

        private float getRightX()
        {
            return Convert.ToSingle(rightXUpDown.Value);
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            drawer = new Drawer(pictureBox1);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pointsList.Count() >1)
            {
                drawer.DrawAxes(e.Graphics, new PointF(getLeftX(), pointsList.Select(u => u.Y).Min()), new PointF(getRightX(), pointsList.Select(u => u.Y).Max()));
                drawer.DrawPlot(pointsList);
            }
        }

        public double formula(float x)
        {

            if (x < A) return -Math.Sqrt(Math.Pow(A, 2F / 3) - Math.Pow(x, 2F / 3));
            return Math.Log(x);
        }

        public double f(float x)
        {
            return Math.Sqrt(Math.Pow(x, 4) + Math.Pow(x, 4 - x)) + Math.Log(Math.Abs(x - 20.5F));
        }



        private void fButton_Click(object sender, EventArgs e)
        {
            pointsList.Clear();
            float left = getLeftX();
           
            
            for (float i = left; i < getRightX(); i += eps)
            {
                double y = f(i);
                if (!Double.IsNaN(y))
                    pointsList.Add(new PointF(i, Convert.ToSingle(y)));
            }

            pictureBox1.Invalidate();
        }

        private void sinButton_Click(object sender, EventArgs e)
        {
            pointsList.Clear();

            for (float i = getLeftX(); i < getRightX(); i += eps)
            {
                pointsList.Add(new PointF(i, Convert.ToSingle(Math.Sin(i))));
            }

            pictureBox1.Invalidate();
        }

        private void cosButton_Click(object sender, EventArgs e)
        {
            pointsList.Clear();

            for (float i = getLeftX(); i < getRightX(); i += eps)
            {
                pointsList.Add(new PointF(i, Convert.ToSingle(Math.Cos(i))));
            }

            pictureBox1.Invalidate();
        }

      

        private void chButton_Click(object sender, EventArgs e)
        {
            pointsList.Clear();

            for (float i = getLeftX(); i < getRightX(); i += eps)
            {
                pointsList.Add(new PointF(i, Convert.ToSingle(Math.Cosh(i))));
            }

            pictureBox1.Invalidate();
        }
    }
}
