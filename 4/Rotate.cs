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
    public partial class Rotate : Form
    {
        public float Phi = 0;

       
        public Rotate()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            Phi = float.Parse(textBox1.Text);
           
            Close();
        }
    }
}
