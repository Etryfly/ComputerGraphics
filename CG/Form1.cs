using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public partial class Form1 : Form
    {
        private int x1, y1, x2, y2;
        private List<Point> ptarray = new List<Point>();
        private double a, t, fi, k;
        private Pen pen = new Pen(Color.DarkRed, 2);

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            fi += 0.05 ;
            int r = 20;

            t = fi;
            x2 =x1 + (int)(r *(k-1)*(Math.Cos(t) + Math.Cos((k-1)*t)/(k-1)));
            y2 = y1 - (int)(r * (k - 1) * (Math.Sin(t) - Math.Sin((k - 1) * t) / (k - 1)));
            //Invalidate();
           // textBox1.Text = fi.ToString();
            pictureBox1.Invalidate();
            //MessageBox.Show("Tick");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            x1 = ClientSize.Width / 2 ;
            y1 = ClientSize.Height / 2;
            int r = 20;
            fi = -0.5;
            t = fi;
            k = 3;
            x2 = x1 + (int)(r * (k - 1) * (Math.Cos(t) + Math.Cos((k - 1) * t) / (k - 1)));
            y2 = y1 - (int)(r * (k - 1) * (Math.Sin(t) - Math.Sin((k - 1) * t) / (k - 1)));
            this.timer1.Enabled = false;
        }
        private void pictureBox1_paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(pen, x2, y2, 20, 20);
            Point point = new Point(x2, y2);
            ptarray.Add(point);
            if (ptarray.Count > 1)
            {
                Point[] points = ptarray.ToArray();
                g.DrawCurve(pen, points);
            }
           //    MessageBox.Show(x2 + " " + y2);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 5;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick_1);
            timer1.Start();

            pictureBox1.Controls.Remove(button1);
            button1.Dispose();
            //eMessageBox.Show("123");
            string kString = comboBox1.SelectedItem.ToString();
            k = Double.Parse(kString);
        }

    }
}
