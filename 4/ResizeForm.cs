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
    public partial class ResizeForm : Form
    {

        public float X = 0;
       
        public float Y = 0;
        public ResizeForm()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           
            X = float.Parse( XtextBox.Text);
            Y = float.Parse( YtextBox.Text);
            Close();
        }

    
    }
}
