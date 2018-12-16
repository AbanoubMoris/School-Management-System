using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class Form2 : SMS.Form1
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 DashBoard = new Form1();
            DashBoard.Show();
            this.Hide();
        }
    }
}
