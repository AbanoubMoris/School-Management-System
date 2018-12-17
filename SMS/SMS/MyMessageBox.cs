using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib ;
namespace SMS
{
    public partial class MyMessageBox : Form
    {
        
        public MyMessageBox()
        {
            InitializeComponent();
            bunifuTransition1.Show(this, true);
           

        }
        public MyMessageBox(string text)
        {
            InitializeComponent();
            
            this.MS.Text = text;
            bunifuTransition1.Show(this, true);
            MS.Left = 100;
            this.Width = MS.Width + 200;
            bunifuThinButton21.Location = new Point(MS.Width + 100, 124);
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
