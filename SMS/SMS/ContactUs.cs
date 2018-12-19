using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class ContactUs : UserControl
    {
        MyMessageBox MBox;
        public ContactUs()
        {
            InitializeComponent();
        }
        bool contact = false;
        private void pictureBox22_Click(object sender, EventArgs e)
        {
            if (!contact)
            {
                contact = true;
                panel3.Visible = false;
                timer1.Enabled = true;

            }
            else
            {
                contact = false;
                panel3.Visible = true;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (contact == false)
            {
                if (panel3.Height >= 260)
                    timer1.Enabled = false;
                panel3.Height += 20;

            }
            else
            {
                if (panel3.Height <= 0)
                    timer1.Enabled = false;
                panel3.Height -= 20;

            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/groups/278788892992065/");
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/SSystem21");
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            MBox = new MyMessageBox("Search For 'schoolsystem21'");
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            MBox = new MyMessageBox("Contact us on '+20-01146728644'");
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/AbanoubMoris/Final-project-isa.com");
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UC8atV55eQ94s3BsLoKJKrrQ?view_as=subscriber");
        }
    }
}
