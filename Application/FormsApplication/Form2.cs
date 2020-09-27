﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormsApplication
{
    public partial class Form2 : Form
    {
        public Form2(string res, TimeSpan time)
        {
            InitializeComponent();
            label1.Text = $"{res} completed its work.";
            label2.Text = $"The running time of the algorithm: {time}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
