using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using WMPLib;
namespace SMS
{
    public partial class Student_Form : Form 
    {
        MyMessageBox MSBOX;
        WindowsMediaPlayer playSound = new WindowsMediaPlayer();
       
        string stringConnection = StringConnection.ConnectionString(); string user_name;
        void showCoursesAvailable(ComboBox c)
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                
                con.Open();
                if(c.Name == "comboBox4")
                {
                    SqlCommand cmd = new SqlCommand("exec getStudentCourses '" + user_name + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c.Items.Add(dr["Course_Name"]);
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("exec showAllCourses", con);
                    SqlDataReader dr = cmd.ExecuteReader();                    
                    while (dr.Read())
                    {
                        c.Items.Add(dr["Course_Name"]);
                    }
                }

            }
        }

        int courseId(ComboBox c)
        {
            int temp = 0;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC studentCourseId '" + c.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp = Int32.Parse(dr["Course_ID"].ToString());
                }
            }
            return temp;
        }
        bool studentAssignedToCourse;

        void studentAlreadyAssigned()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec getStudentCourses '" + user_name + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    studentAssignedToCourse = false;
                    if(comboBox2.Text == dr["Course_Name"].ToString())
                    {
                        studentAssignedToCourse = true;
                        break;
                    }
                }

            }
        }


        public Student_Form(String userName)
        {
            this.user_name = userName;
            InitializeComponent();
            showCoursesAvailable(comboBox4);
            showCoursesAvailable(comboBox2);
            showCoursesAvailable(comboBox1);
        }

        private void Student_Form_Load(object sender, EventArgs e)
        {
           
            ExitPic.BackColor = Color.Transparent;
            
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
           
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }
        private void ExitPic_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            
           
            Personal_pnl.Visible = false;
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }
        
        private void UandP_btn_Click(object sender, EventArgs e)
        {

            attendance_pnl.Visible = false;
        
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;

        }

        private void personal_btn_Click(object sender, EventArgs e)
        {
           
            Personal_pnl.Visible = true;
            attendance_pnl.Visible = false;
           
            courses_pnl.Visible = false;
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
       
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {

            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
         
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }

        private void label24_Click(object sender, EventArgs e)
        {

            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
       
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }

    
        private void label20_Click(object sender, EventArgs e)
        {

            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
 
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }
        bool showGradesBTN = false, statusBTN = false;
        private void Showgrades_btn_Click(object sender, EventArgs e)
        {
            grades_pnl.Visible = true;
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
       
            status_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            showGradesBTN = true;
            statusBTN = false;
        }

        private void Status_btn_Click(object sender, EventArgs e)
        {
            status_pnl.Visible = true;
      
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            grades_pnl.Visible = false;
            comboBox3.Text = "";
            label10.Text = "";
            statusBTN = true;
            showGradesBTN = false;
        }

        private void EditData_btn_Click(object sender, EventArgs e)
        {
           // EditData_pnl.Visible = true;
            Personal_pnl.Visible = true;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            editDataAppearance();
            comboBox3.Text = "";
            label10.Text = "";

        }

        private void Choosecourses_btn_Click(object sender, EventArgs e)
        {
            courses_pnl.Visible = true;
            Personal_pnl.Visible = false;
            attendance_pnl.Visible = false;
            
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            comboBox3.Text = "";
            label10.Text = "";
        }

        private void Attendance_btn_Click(object sender, EventArgs e)
        {
            attendance_pnl.Visible = true;
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
           
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            comboBox3.Text = "";
            label10.Text = "";
        }

        private void label20_Click_1(object sender, EventArgs e)
        {
            Personal_pnl.Visible = false;
            attendance_pnl.Visible = false;
           
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            studentAlreadyAssigned();
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                if (studentAssignedToCourse)
                {
                    MessageBox.Show("You are already assigned to this course!");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("EXEC getStudentID '" + user_name + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    int studID = Int32.Parse(dr["Student_ID"].ToString());
                    dr.Close();
                    int course_ID = courseId(comboBox2);
                    SqlCommand cmd2 = new SqlCommand("EXEC addCoursesStud " + studID + "," + course_ID, con);
                    cmd2.ExecuteNonQuery();
                    playSound.URL = "error.wav";
                    playSound.controls.play();
                    MessageBox.Show("You have been assigned to this course!");
                    comboBox2.Text = "";

                }
            }

        }

    

        private void label25_Click(object sender, EventArgs e)
        {
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
           
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }

        private void label28_Click(object sender, EventArgs e)
        {
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
           
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }

        private void label25_Click_1(object sender, EventArgs e)
        {
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
           
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
        }

       
        private void label30_Click(object sender, EventArgs e)
        {
            ShowCourses_pnl.Visible = false;
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
        
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
        }

        private void ShowCourses_btn_Click(object sender, EventArgs e)
        {
            ShowCourses_pnl.Visible = true;
            Personal_pnl.Visible = false;
            courses_pnl.Visible = false;
            attendance_pnl.Visible = false;
            status_pnl.Visible = false;
            grades_pnl.Visible = false;
            comboBox3.Text = "";
            label10.Text = "";
            showCourses();
        }

        //function to show all courses that student assigned in
        void showCourses()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from showStudentAssignedCourses('" + user_name + "')", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Course_ID");
                dt.Columns.Add("Course_Name");
                DataRow row;
                while (dr.Read())
                {
                    row = dt.NewRow();
                    row["Course_ID"] = dr["Course_ID"];
                    row["Course_Name"] = dr["Course_Name"];
                    dt.Rows.Add(row);
                }
                dr.Close();
                con.Close();
                dataGridView3.DataSource = dt;
                dataGridView3.BorderStyle = BorderStyle.Fixed3D;
                dataGridView3.AllowUserToResizeColumns = false;
                dataGridView3.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGridView3.AllowUserToResizeRows = false;
                dataGridView3.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView3.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView3.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                //setting color of alternating rows
                dataGridView3.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                // Specify a larger font for columns. 
                dataGridView3.DefaultCellStyle.Font = new Font("Bold Italic", 12);
            }
        }
        //Function to make studentData appears in textboxes
        void editDataAppearance()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *  from studentEditDataAppearence ('" + user_name + "')", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    NameEditData.Text = dr["Name"].ToString();
                    EmailEditData.Text = dr["Email"].ToString();
                    AddressEditData.Text = dr["Address"].ToString();
                    phoneNumberEditData.Text = dr["PhoneNumber"].ToString();
                    passwordEditData.Text = dr["pass"].ToString();
                    if (dr["Gender"].ToString() == "Male")
                    {
                        maleCheckBox.Checked = true;
                    }
                    else
                    {
                        femaleCheckBox.Checked = true;
                    }
                }
            }
        }

        String isMale(bool male)
        {
            return male == true ? "Male" : "Female";
        }

        //Function to EditStudentData
        void editData()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXECUTE studentEditData @oldName = '" + user_name + "', @Name = '" + NameEditData.Text + "', @phone = '" + phoneNumberEditData.Text + "', @Gender = '" + isMale(maleCheckBox.Checked) + "', @address = '" + AddressEditData.Text + "', @email = '"+ EmailEditData.Text + "', @pass = '" + passwordEditData.Text + "'", con);
                cmd.ExecuteNonQuery();
                playSound.URL = "done.mp3";
                playSound.controls.play();
                MSBOX = new MyMessageBox("Your data has been updated!");
            
            }

        }

        
        private void Done_Click(object sender, EventArgs e)
        {
            editData();
            playSound.URL = "do.mp3";
            playSound.controls.play();
            MSBOX = new MyMessageBox("Please login again to save your data!");
            this.Hide();
            Login log = new Login();
            log.Show();
        }


        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            showGrades(comboBox3);
        }

        void showGrades(ComboBox c)
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Grade , Status from showGrade(" + courseId(c) + ") where Name = '" + user_name + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (showGradesBTN)
                {
                    if (comboBox3.Text == "")
                    {
                    }
                    else if (!(dr.HasRows))
                    {
                        playSound.URL = "error.wav";
                        playSound.controls.play();
                        MSBOX = new MyMessageBox("No Grades are available right now or you are not assigned to this course!");

                    }
                    else
                    {
                        label10.Text = dr["Grade"].ToString();
                    }
                }
                else if (statusBTN)
                {
                    if (dr["Status"].ToString()!=null)
                    {
                        string status = dr["Status"].ToString();
                        label29.Text = status;
                    }
                }
            }
        }


        //show attendance for specific subject
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int courseID = courseId(comboBox1);
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from showAttendance(" + courseID + ") where Name = '" + user_name + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Student_ID");
                dt.Columns.Add("Course_ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Attendance");
                DataRow row;
                while (dr.Read())
                {
                    row = dt.NewRow();
                    row["Student_ID"] = dr["Student_ID"];
                    row["Course_ID"] = dr["Course_ID"];
                    row["Name"] = dr["Name"];
                    row["Attendance"] = dr["Attendance"];
                    dt.Rows.Add(row);
                }
                dr.Close();
                con.Close();
                dataGridView1.DataSource = dt;
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                //setting color of alternating rows
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                // Specify a larger font for columns. 
                dataGridView1.DefaultCellStyle.Font = new Font("Bold Italic", 12);
            }
        }

        private void Buttons_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login Lgin = new Login();
            Lgin.Show();
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_TextChanged_1(object sender, EventArgs e)
        {

            showGrades(comboBox4);
        }

    
    }
}
