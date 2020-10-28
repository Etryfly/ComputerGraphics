using System;
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
    public partial class RotatePointForm : Form
    {

        public float Angle;
        public float X;
        public float Y;
        public RotatePointForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Angle = float.Parse( AngleTextBox.Text);
            X = float.Parse( XTextBox.Text);
            Y = float.Parse( YTextBox.Text);
            Close();
        }
    }
}
