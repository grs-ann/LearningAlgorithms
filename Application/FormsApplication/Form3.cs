using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormsApplication
{
    public partial class Form3 : Form
    {
        public Form3(List<string> lst)
        {
            InitializeComponent();
            label1.Text = lst.Count.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
