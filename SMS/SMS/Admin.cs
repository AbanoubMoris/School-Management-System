using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
using WMPLib;
namespace SMS
{

    public partial class Admin : Form
    {
        bool isclicked1 = false;
        bool isclicked2 = false;
        bool isclicked3 = false;

       
        
        bool hidden = false;
        string stringConnection = StringConnection.ConnectionString();
        public Admin()
        {
            InitializeComponent();
            timer1.Enabled = true;
            hidden = true;
            AdminFunctions MyFn = new AdminFunctions();
            PPanel.AutoScroll = true;
            TPanel.AutoScroll = true;
            SPan.AutoScroll = true;
            MyFn.TeacherData(TPanel);
            MyFn.ParentData(PPanel);
            MyFn.StudentData(SPan);
            All_counts_panel.Visible = false;
            student_MF_pnl.Visible = false;
            teacher_MF_pnl.Visible = false;
           

        }

        public string TeacherName
        {
            get { return label8.Text; }
            set { label8.Text = value; }
        }
        public string courseName
        {
            get { return label9.Text; }
            set { label9.Text = value; }
        }
        public string FName
        {
            get { return Fname.Text; }
            set { Fname.Text = value; }
        }
        public string Address
        {
            get { return city.Text; }
            set { city.Text = value; }
        }
        public string Gender
        {
            get { return gender.Text; }
            set { gender.Text = value; }
        }
        public string Age
        {
            get { return age.Text; }
            set { age.Text = value; }
        }

        public string Pname
        {
            get { return ParentNm.Text; }
            set { ParentNm.Text = value; }
        }
        public string PID
        {
            get { return ParentID.Text; }
            set { ParentID.Text = value; }
        }
        public string PCity
        {
            get { return ParentCity.Text; }
            set { ParentCity.Text = value; }
        }
        public string PAge
        {
            get { return ParentAge.Text; }
            set { ParentAge.Text = value; }
        }
        public string PGender
        {
            get { return ParentGender.Text; }
            set { ParentGender.Text = value; }
        }
        public string PPhone
        {
            get { return ParentPhone.Text; }
            set { ParentPhone.Text = value; }
        }
        public string PEmail
        {
            get { return ParentEmail.Text; }
            set { ParentEmail.Text = value; }
        }

        public string StdPhone
        {
            get { return SPhone.Text; }
            set { SPhone.Text = value; }
        }
        public string Stdname
        {
            get { return Sname.Text; }
            set { Sname.Text = value; }
        }
        public string StdAge
        {
            get { return SAge.Text; }
            set { SAge.Text = value; }
        }
        public string StdGender
        {
            get { return SGender.Text; }
            set { SGender.Text = value; }
        }
        public string StdMail
        {
            get { return Smail.Text; }
            set { Smail.Text = value; }
        }
        public string StdCity
        {
            get { return Scity.Text; }
            set { Scity.Text = value; }
        }
        public string StdID
        {
            get { return SID.Text; }
            set { SID.Text = value; }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button1.Location.Y);

            AboutPnl.Visible = false;
            DashBoardPanel.Visible = true;
            TeachersPanel.Visible = false;
            StudentsPanel.Visible = false;
            SubjectPanel.Visible = false;
            GradesPanel.Visible = false;
            ParentPanel.Visible = false;
            //  TeacherDetailsPanel.Visible = false;
            //*****************************************************
            All_chart.Visible = false;
            Teachers_chart.Visible = false;
            Students_chart.Visible = false;
            button7.ForeColor = Color.White;
            button8.ForeColor = Color.White;
            button9.ForeColor = Color.White;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button2.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            ParentPanel.Visible = false;
            StudentsPanel.Visible = false;
            SubjectPanel.Visible = false;
            GradesPanel.Visible = false;
            TeachersPanel.Visible = true;
            // TeacherDetailsPanel.Visible = true;
            TeachersPanel.BringToFront();

            //TeacherDetailsPanel.BringToFront();

            //TeacherForm T = new TeacherForm();
            //T.ShowDialog();
            //*****************************************************
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button3.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            StudentsPanel.Visible = false;
            SubjectPanel.Visible = false;
            //TeacherDetailsPanel.Visible = false;
            GradesPanel.Visible = false;
            ParentPanel.Visible = true;
            ParentPanel.BringToFront();
            //*****************************************************
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button4.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            ParentPanel.Visible = false;
            SubjectPanel.Visible = false;
            // TeacherDetailsPanel.Visible = false;
            GradesPanel.Visible = false;
            StudentsPanel.Visible = true;
            StudentsPanel.BringToFront();
            //*****************************************************
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button5.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            ParentPanel.Visible = false;
            StudentsPanel.Visible = false;
            // TeacherDetailsPanel.Visible = false;
            GradesPanel.Visible = false;
            SubjectPanel.Visible = true;
            SubjectPanel.AutoScroll = true;

            SubjectPanel.BringToFront();
            //*****************************************************
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button6.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            ParentPanel.Visible = false;
            StudentsPanel.Visible = false;
            //    TeacherDetailsPanel.Visible = false;
            SubjectPanel.Visible = false;
            GradesPanel.Visible = true;
            GradesPanel.BringToFront();
            //*****************************************************
            results_pnl.Visible = false;
            // isclicked = true;
        }

        private void GradesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void TeacherDetailsPanel_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isclicked1 == false)
            {
                button7.ForeColor = Color.Green;
                button8.ForeColor = Color.White;
                button8.ForeColor = Color.White;
                All_chart.Visible = true;
                Teachers_chart.Visible = false;
                Students_chart.Visible = false;
                All_counts_panel.Visible = true;
                student_MF_pnl.Visible = false;
                teacher_MF_pnl.Visible = false;
                All_chart.Titles.Add("All DashBroud chart");

                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select count(Name) from Teacher", con);
                int count1 = (int)cmd1.ExecuteScalar();
                All_chart.Series["s1"].Points.AddXY("Teachers", count1);
                techers_count.Text = count1.ToString();

                SqlCommand cmd2 = new SqlCommand("select count(Name) from Student", con);
                int count2 = (int)cmd2.ExecuteScalar();
                All_chart.Series["s1"].Points.AddXY("Students", count2);
                stud_count.Text = count2.ToString();

                SqlCommand cmd3 = new SqlCommand("select count(Course_Name) from Course", con);
                int count3 = (int)cmd3.ExecuteScalar();
                All_chart.Series["s1"].Points.AddXY("Courses", count3);
                courses_count.Text = count3.ToString();
                con.Close();
            }
            else
            {
                button7.ForeColor = Color.Green;
                button8.ForeColor = Color.White;
                button9.ForeColor = Color.White;
                All_chart.Visible = true;
                Teachers_chart.Visible = false;
                Students_chart.Visible = false;
                All_counts_panel.Visible = true;
                student_MF_pnl.Visible = false;
                teacher_MF_pnl.Visible = false;
            }
            isclicked1 = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isclicked2 == false)
            {
                button7.ForeColor = Color.White;
                button8.ForeColor = Color.Green;
                button9.ForeColor = Color.White;
                All_chart.Visible = false;
                Students_chart.Visible = false;
                Teachers_chart.Visible = true;
                teacher_MF_pnl.Visible = true;
                student_MF_pnl.Visible = false;
                All_counts_panel.Visible = false;
                Teachers_chart.Titles.Add("Teachers DashBroud chart");

                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select count(Gender) from Teacher where Gender like 'Male'", con);
                int count1 = (int)cmd1.ExecuteScalar();
                Teachers_chart.Series["s1"].Points.AddXY("Male", count1);
                malecount.Text = count1.ToString();

                SqlCommand cmd2 = new SqlCommand("select count(Gender) from Teacher where Gender like 'Female'", con);
                int count2 = (int)cmd2.ExecuteScalar();
                Teachers_chart.Series["s1"].Points.AddXY("Female", count2);
                femalecount.Text = count2.ToString();
                con.Close();
            }
            else
            {
                button7.ForeColor = Color.White;
                button8.ForeColor = Color.Green;
                button9.ForeColor = Color.White;
                Teachers_chart.Visible = true;
                teacher_MF_pnl.Visible = true;
                student_MF_pnl.Visible = false;
                All_chart.Visible = false;
                Students_chart.Visible = false;
                All_counts_panel.Visible = false;
            }
            isclicked2 = true;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isclicked3 == false)
            {
                button7.ForeColor = Color.White;
                button8.ForeColor = Color.White;
                button9.ForeColor = Color.Green;
                All_chart.Visible = false;
                Teachers_chart.Visible = false;
                Students_chart.Visible = true;
                student_MF_pnl.Visible = true;
                teacher_MF_pnl.Visible = false;
                All_counts_panel.Visible = false;
                Students_chart.Titles.Add("Students DashBroud chart");
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();

                SqlCommand cmd1 = new SqlCommand("select count(Gender) from Student where Gender like 'Male'", con);
                int count1 = (int)cmd1.ExecuteScalar();
                Students_chart.Series["s1"].Points.AddXY("Male", (count1));
                Male_C.Text = count1.ToString();
                SqlCommand cmd2 = new SqlCommand("select count(Gender) from Student where Gender like 'Female'", con);
                int count2 = (int)cmd2.ExecuteScalar();
                Students_chart.Series["s1"].Points.AddXY("Female", (count2));
                female_C.Text = count2.ToString();
                con.Close();
                Students_chart.Visible = true;
            }
            else
            {
                button7.ForeColor = Color.White;
                button8.ForeColor = Color.White;
                button9.ForeColor = Color.Green;
                All_chart.Visible = false;
                Teachers_chart.Visible = false;
                student_MF_pnl.Visible = true;
                Students_chart.Visible = true;
                teacher_MF_pnl.Visible = false;
                All_counts_panel.Visible = false;

            }
            isclicked3 = true;
        }


        private void math_btn_Click(object sender, EventArgs e)
        {
            math_btn.ForeColor = Color.Green;
            English_btn.ForeColor = Color.White;
            geo_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.White;
            Physics_btn.ForeColor = Color.White;
            Arabic_btn.ForeColor = Color.White;
            Germany_btn.ForeColor = Color.White;
            Chemistry_btn.ForeColor = Color.White;
            history_btn.ForeColor = Color.White;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 2 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }
        }
        private void English_btn_Click(object sender, EventArgs e)
        {
            English_btn.ForeColor = Color.Green;
            math_btn.ForeColor = Color.White;
            geo_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.White;
            Physics_btn.ForeColor = Color.White;
            Arabic_btn.ForeColor = Color.White;
            Germany_btn.ForeColor = Color.White;
            Chemistry_btn.ForeColor = Color.White;
            history_btn.ForeColor = Color.White;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 6 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }
        }
        private void geo_btn_Click(object sender, EventArgs e)
        {
            geo_btn.ForeColor = Color.Green;
            math_btn.ForeColor = Color.White;
            English_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.White;
            Physics_btn.ForeColor = Color.White;
            Arabic_btn.ForeColor = Color.White;
            Germany_btn.ForeColor = Color.White;
            Chemistry_btn.ForeColor = Color.White;
            history_btn.ForeColor = Color.White;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 10 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }
        }

        private void spain_btn_Click(object sender, EventArgs e)
        {
            math_btn.ForeColor = Color.White;
            English_btn.ForeColor = Color.White;
            geo_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.Green;
            Physics_btn.ForeColor = Color.White;
            Arabic_btn.ForeColor = Color.White;
            Germany_btn.ForeColor = Color.White;
            Chemistry_btn.ForeColor = Color.White;
            history_btn.ForeColor = Color.White;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 9 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }
        }

        private void history_btn_Click(object sender, EventArgs e)
        {
            math_btn.ForeColor = Color.White;
            English_btn.ForeColor = Color.White;
            geo_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.White;
            Physics_btn.ForeColor = Color.White;
            Arabic_btn.ForeColor = Color.White;
            Germany_btn.ForeColor = Color.White;
            Chemistry_btn.ForeColor = Color.White;
            history_btn.ForeColor = Color.Green;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 8 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }
        }

        private void Chemistry_btn_Click(object sender, EventArgs e)
        {
            math_btn.ForeColor = Color.White;
            English_btn.ForeColor = Color.White;
            geo_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.White;
            Physics_btn.ForeColor = Color.White;
            Arabic_btn.ForeColor = Color.White;
            Germany_btn.ForeColor = Color.White;
            Chemistry_btn.ForeColor = Color.Green;
            history_btn.ForeColor = Color.White;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 7 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }
        }

        private void Arabic_btn_Click(object sender, EventArgs e)
        {
            math_btn.ForeColor = Color.White;
            English_btn.ForeColor = Color.White;
            geo_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.White;
            Physics_btn.ForeColor = Color.White;
            Arabic_btn.ForeColor = Color.Green;
            Germany_btn.ForeColor = Color.White;
            Chemistry_btn.ForeColor = Color.White;
            history_btn.ForeColor = Color.White;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 5 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }

        }

        private void Physics_btn_Click(object sender, EventArgs e)
        {
            math_btn.ForeColor = Color.White;
            English_btn.ForeColor = Color.White;
            geo_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.White;
            Physics_btn.ForeColor = Color.Green;
            Arabic_btn.ForeColor = Color.White;
            Germany_btn.ForeColor = Color.White;
            Chemistry_btn.ForeColor = Color.White;
            history_btn.ForeColor = Color.White;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 4 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }
        }

        private void Germany_btn_Click(object sender, EventArgs e)
        {
            math_btn.ForeColor = Color.White;
            English_btn.ForeColor = Color.White;
            geo_btn.ForeColor = Color.White;
            spain_btn.ForeColor = Color.White;
            Physics_btn.ForeColor = Color.White;
            Arabic_btn.ForeColor = Color.White;
            Germany_btn.ForeColor = Color.Green;
            Chemistry_btn.ForeColor = Color.White;
            history_btn.ForeColor = Color.White;
            results_pnl.Visible = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                using (SqlCommand cmd = new SqlCommand("select Name , Grade from  Student , Student_Course where Course_ID = 3 and Stud_ID = Student_ID", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable tbl = new DataTable();
                    tbl.Load(reader);
                    Math_res_datagrid.DataSource = tbl;
                }
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login lgin = new Login();
            lgin.Show();
            this.Hide();
        }
        private void pictureBox21_Click(object sender, EventArgs e)
        {
            if (!hidden)
            {
                timer1.Enabled = true;
                hidden = true;
                // panel1.Visible = false;

            }
            else
            {
                bunifuTransition1.HideSync(panel1);
                bunifuTransition1.ShowSync(panel1);
                hidden = false;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hidden == false)
            {
                if (panel1.Width >= 210)
                    timer1.Enabled = false;
                panel1.Width += 10;
                TeachersPanel.Left += 10;
                GradesPanel.Left += 10;
                StudentsPanel.Left += 10;
                SubjectPanel.Left += 10;
                ParentPanel.Left += 10;
                DashBoardPanel.Left += 10;
            }
            else
            {
                if (panel1.Width <= 60)
                    timer1.Enabled = false;
                panel1.Width -= 10;
                TeachersPanel.Left -= 10;
                GradesPanel.Left -= 10;
                StudentsPanel.Left -= 10;
                SubjectPanel.Left -= 10;
                ParentPanel.Left -= 10;
                DashBoardPanel.Left -= 10;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button1.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = true;
            TeachersPanel.Visible = false;
            StudentsPanel.Visible = false;
            SubjectPanel.Visible = false;
            GradesPanel.Visible = false;
            ParentPanel.Visible = false;
            //  TeacherDetailsPanel.Visible = false;
            //*****************************************************
            All_chart.Visible = false;
            Teachers_chart.Visible = false;
            Students_chart.Visible = false;
            button7.ForeColor = Color.White;
            button8.ForeColor = Color.White;
            button9.ForeColor = Color.White;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button2.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            ParentPanel.Visible = false;
            StudentsPanel.Visible = false;
            SubjectPanel.Visible = false;
            GradesPanel.Visible = false;
            TeachersPanel.Visible = true;
            // TeacherDetailsPanel.Visible = true;
            TeachersPanel.BringToFront();

            //TeacherDetailsPanel.BringToFront();

            //TeacherForm T = new TeacherForm();
            //T.ShowDialog();
            //*****************************************************
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button3.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            StudentsPanel.Visible = false;
            SubjectPanel.Visible = false;
            //TeacherDetailsPanel.Visible = false;
            GradesPanel.Visible = false;
            ParentPanel.Visible = true;
            ParentPanel.BringToFront();
            //*****************************************************
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button4.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            ParentPanel.Visible = false;
            SubjectPanel.Visible = false;
            // TeacherDetailsPanel.Visible = false;
            GradesPanel.Visible = false;
            StudentsPanel.Visible = true;
            StudentsPanel.BringToFront();
            //*****************************************************
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button5.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            ParentPanel.Visible = false;
            StudentsPanel.Visible = false;
            // TeacherDetailsPanel.Visible = false;
            GradesPanel.Visible = false;
            SubjectPanel.Visible = true;
            SubjectPanel.AutoScroll = true;

            SubjectPanel.BringToFront();
            //*****************************************************
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            SlidePanel.Location = new Point(1, button6.Location.Y);
            AboutPnl.Visible = false;
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            ParentPanel.Visible = false;
            StudentsPanel.Visible = false;
            //    TeacherDetailsPanel.Visible = false;
            SubjectPanel.Visible = false;
            GradesPanel.Visible = true;
            GradesPanel.BringToFront();
            //*****************************************************
            results_pnl.Visible = false;
            // isclicked = true;
        }


        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void Male_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox22_Click_1(object sender, EventArgs e)
        {
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            ParentPanel.Visible = false;
            StudentsPanel.Visible = false;
            //    TeacherDetailsPanel.Visible = false;
            SubjectPanel.Visible = false;
            GradesPanel.Visible = false;
            GradesPanel.BringToFront();
            //*****************************************************
            results_pnl.Visible = false;
            AboutPnl.Visible = true;
            aboutUs1.Location = new Point(aboutUs1.Location.X-60, 50);
            timer3.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (aboutUs1.Location.Y <= -1400) timer3.Enabled = false;
            aboutUs1.Location = new Point(aboutUs1.Location.X, aboutUs1.Location.Y - 5);
            userControl21.Location = new Point(aboutUs1.Location.X, aboutUs1.Location.Y + aboutUs1.Height);
            George.Location = new Point(aboutUs1.Location.X, aboutUs1.Location.Y + aboutUs1.Height + userControl21.Height);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            DashBoardPanel.Visible = false;
            TeachersPanel.Visible = false;
            ParentPanel.Visible = false;
            StudentsPanel.Visible = false;
            //    TeacherDetailsPanel.Visible = false;
            SubjectPanel.Visible = false;
            GradesPanel.Visible = false;
            GradesPanel.BringToFront();
            //*****************************************************
            results_pnl.Visible = false;
            AboutPnl.Visible = true;
            aboutUs1.Location = new Point(aboutUs1.Location.X, 50);
            timer3.Enabled = true;
        }
    }
}
