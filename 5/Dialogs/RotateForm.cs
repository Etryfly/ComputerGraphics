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
    public partial class RotateForm : Form
    {
        public RotateForm()
        {
            InitializeComponent();
        }

        public float Angle;

        private void button1_Click(object sender, EventArgs e)
        {
            Angle = (float)(float.Parse(textBox1.Text) * 180 / Math.PI);
            Close();
        }
    }
}