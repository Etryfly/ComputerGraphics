using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5
{
    public partial class ResizeForm : Form
    {
        public ResizeForm()
        {
            InitializeComponent();
        }

        public float X, Y, Z;

        private void button1_Click(object sender, EventArgs e)
        {
            X = float.Parse(textBox1.Text);
            Y = float.Parse(textBox2.Text);
            Z = float.Parse(textBox3.Text);
            Close();
        }
    }
}
