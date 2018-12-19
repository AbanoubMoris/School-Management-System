using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SMS
{

    public partial class Teachers : UserControl
    {

        public Teachers()
        {
            InitializeComponent();

        }
        public Label TeacherName
        {
            get { return label3; }
            set { label3.Text = value.ToString(); }
        }
        public Label TeacherSubject
        {
            get { return label1; }
            set { label1.Text = value.ToString(); }
        }
        public Image Picture
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        private void Teachers_Load(object sender, EventArgs e)
        {

        }

        private void Teachers_Click(object sender, EventArgs e)
        {
            ReadDataForAdmin Rd = new ReadDataForAdmin();
            var singleton = Singleton.Instance;
            var f = singleton.AdminForm;
            if (this.Name == "Teacher")
            {
                byte[] im = null;
                List<string> s = Rd.Teacherdetails(label3.Text.ToString() , ref im);
                f.TeacherName = s[1];
                f.FName = s[1];
                f.Address = s[3];
                f.Gender = s[5];
                string currentYear = DateTime.Now.Year.ToString();
                int cur = Int32.Parse(currentYear);
                int pres = Int32.Parse(s[6]);
                currentYear = (cur - pres).ToString();
                f.Age = currentYear + " years old";
                f.courseName = label1.Text.ToString();
                MemoryStream ms = new MemoryStream(im);
                f.tePic = Image.FromStream(ms);

                // byte[] img = System.Text.ASCIIEncoding.ASCII.GetBytes(s[7]); //*****************************

                //A.Show();
                //*********************************
                //f.LabelText = label3.Text.ToString();
            }
            else if (this.Name == "Parent")
            {
                byte[] im = null;
                List<string> s = Rd.Parentdetails(label1.Text.ToString(),ref im);
                MemoryStream ms = new MemoryStream(im);
                f.PaPic = Image.FromStream(ms);
                f.PID = s[0];
                f.Pname = s[1];
                f.PPhone = s[2];
                f.PCity = s[3];
                f.PEmail = s[4];
                f.PGender = s[5];
                string currentYear = DateTime.Now.Year.ToString();
                int cur = Int32.Parse(currentYear);
                int pres = Int32.Parse(s[6]);
                currentYear = (cur - pres).ToString();
                f.PAge = currentYear + " years old";
                //f.courseName = label1.Text.ToString();
                
            }
            else if (this.Name == "Student")
            {

                byte[] im = null;
                List<string> s = Rd.Studentdetails(label1.Text.ToString(), ref im);
                MemoryStream ms = new MemoryStream(im);
                f.StdPc = Image.FromStream(ms);

                f.StdID = s[0];
                f.Stdname = s[1];
                f.StdPhone = s[2];
                f.StdCity = s[3];
                f.StdMail = s[4];
                f.StdGender = s[5];
                string currentYear = DateTime.Now.Year.ToString();
                int cur = Int32.Parse(currentYear);
                int pres = Int32.Parse(s[6]);
                currentYear = (cur - pres).ToString();
                f.StdAge = currentYear + " years old";
                //f.courseName = label1.Text.ToString();

            }
        }
    }
}
