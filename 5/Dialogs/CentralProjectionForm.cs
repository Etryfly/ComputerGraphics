﻿using System;
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
    public partial class CentralProjectionForm : Form
    {

        public float Z;
        public CentralProjectionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Z = float.Parse(textBox1.Text);
            Close();
        }
    }
}
