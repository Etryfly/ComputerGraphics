using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5.Dialogs
{
    public partial class ObliqueProjectionForm : Form
    {
        public ObliqueProjectionForm()
        {
            InitializeComponent();
        }

        public float Alpha, L;

        private void button1_Click(object sender, EventArgs e)
        {
            Alpha = (float)((float.Parse(AlphaTextBox.Text) *  Math.PI) / 180);
            L = float.Parse(LTextBox.Text);
            Close();
        }
    }
}
