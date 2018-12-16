using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox()
        {
            InitializeComponent();
            
            bunifuTransition1.Show(this,true);
            //this.ShowDialog();
        }
        public MyMessageBox(string text)
        {
            InitializeComponent();
            this.MS.Text = text;
            bunifuTransition1.Show(this, true);
            this.ShowDialog();
        }
        public Label MSBOX
        {
            get { return MS; }
            set { MS.Text = value.ToString(); }
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFormFadeTransition1_TransitionEnd(object sender, EventArgs e)
        {
            //bunifuFormFadeTransition1.HideAsyc(this, true);
        }
    }
}
