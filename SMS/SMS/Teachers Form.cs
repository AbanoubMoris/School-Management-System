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
    public partial class Teachers_Form : Form
    {
        string teacherEmail;
        WindowsMediaPlayer playSound = new WindowsMediaPlayer();
        MyMessageBox MSBOX;
        MyMessageBox MSBox;
        string stringConnection = StringConnection.ConnectionString();
        SmtpClient client;
        MailMessage msg;

        //Function to teacherPassword
        void changePass()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select Name,pass from Teacher where Name = '" + textBox2.Text + "' and pass = '" + textBox9.Text + "';", con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["Name"].ToString() == textBox2.Text && dr["pass"].ToString() == textBox9.Text)
                        {
                            sendEmail(teacherEmail);
                            break;
                        }

                    }
                }

            } 

        }
        void sendEmail(string userEmail)
        {
            client = new SmtpClient();
            msg = new MailMessage();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("schoolsystem21@gmail.com", "Fcis2021");
            msg.From = new MailAddress("schoolsystem21@gmail.com");
            msg.To.Add(new MailAddress(userEmail));
            msg.Subject = "Alert!";
            //send email if Grade Notification selected
            if (isGradenotify)
            {
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Grade from showGrade(" + courseId() + ") where Student_ID = " + StudentIDNotify.Text, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    msg.Body = "Your son's/Daughter's grade is : " + dr["Grade"].ToString();
                }
                client.Send(msg);
                playSound.URL = "done.mp3";
                playSound.controls.play();
                MSBox = new MyMessageBox("An Email has been sent to the Parent!");
              
            }
            //send email if attendance Notification selected
            else if (isAttendance)
            {
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Attendance from showAttendance(" + courseId() + ") where Student_ID = " + StudentIDNotify.Text, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    msg.Body = "Your son's/Daughter's Total Number Of Attendance is : " + dr["Attendance"].ToString();
                }
                client.Send(msg);
                playSound.URL = "done.mp3";
                playSound.controls.play();
                MSBox = new MyMessageBox("An Email has been sent to the Parent!");
               
            }
            //send email if editData is selected
            else if (isEditData)
            {
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update Teacher set pass = '" + textBox3.Text + "' where Email = '" + userEmail + "'", con);
                    cmd.ExecuteNonQuery();
                }
                msg.Body = "This is an automated notification regarding the recent change(s) made to your Account: " + userEmail + " \n\n Your password has recently been modified through the account management system.\n\nIf you did not change your password,please contact us on our Email:schoolsystem21@gmail.com!";
                client.Send(msg);
                playSound.URL = "done.mp3";
                playSound.controls.play();
                MSBox = new MyMessageBox("Your Password Has Been Changed!");
                
            }
            else if(isStatusNotify)
            {
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select status from showAttendance ("+courseId()+") where Name = '"+user_name+"'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    msg.Body = "Your child status: " + dr["Status"].ToString();

                    
                }
                client.Send(msg);
                playSound.URL = "done.mp3";
                playSound.controls.play();
                MSBox = new MyMessageBox("An Email has been sent!");

            }
            
        }


        String user_name;
        public Teachers_Form(string username)
        {
            InitializeComponent();
            user_name = username;
        }

        private void Teachers_Form_Load(object sender, EventArgs e)
        {
           
            label2.BackColor = Color.Transparent;
            
            back_label.BackColor = Color.Transparent;
          
            notify_pnl.Visible = false;
            attend_pnl.Visible = false;
            attend_pnl.Visible = false;
            Addgreades_pnl.Visible = false;
            EditData_pnl.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            Application.Exit();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            notify_pnl.Visible = true;
            attend_pnl.Visible = false;
            Addgreades_pnl.Visible = false;
            EditData_pnl.Visible = false;
            showStudentIDS();
            button1.Visible = true;
            button5.Visible = true;
            button8.Visible = true;

        }

        private void label3_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            attend_pnl.Visible = true;
            notify_pnl.Visible = false;
            Addgreades_pnl.Visible = false;
            EditData_pnl.Visible = false;
            showAttendance();
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            attend_pnl.Visible = false;
            notify_pnl.Visible = false;
            Addgreades_pnl.Visible = false;
        }

        private void grades_btn_Click(object sender, EventArgs e)
        {
            Addgreades_pnl.Visible = true;
            attend_pnl.Visible = false;
            notify_pnl.Visible = false;
            EditData_pnl.Visible = false;
            showGrades();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Addgreades_pnl.Visible = false;
            attend_pnl.Visible = false;
            notify_pnl.Visible = false;
        }
        bool isEditData = false, isGradenotify = false, isAttendance = false;

        private void data_btn_Click(object sender, EventArgs e)
        {
            isEditData = true;
            isGradenotify = false;
            isAttendance = false;
            EditData_pnl.Visible = true;
            Addgreades_pnl.Visible = false;
            attend_pnl.Visible = false;
            notify_pnl.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            playSound.URL = "error.wav";
            playSound.controls.play();
            MSBox = new MyMessageBox("Please confirm your username and password first!");
            
        }


        private void label19_Click(object sender, EventArgs e)
        {
            if(!(textBox2.Text=="" && textBox3.Text==""  && textBox9.Text==""))
            changePass();
            playSound.URL = "do.mp3";
            playSound.controls.play();
            MSBOX = new MyMessageBox("Please login again to save your data!");
            this.Hide();
            Login log = new Login();
            log.Show();
        }


        private void label20_Click(object sender, EventArgs e)
        {
            editData();
            playSound.URL = "do.mp3";
            playSound.controls.play();
            MSBOX = new MyMessageBox("Please login again to save your data!");
            this.Hide();
            Login log = new Login();
            log.Show();
        }
        string username, pass;
      

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        String isMale(bool male)
        {
            return male == true ? "Male" : "Female";
        }
        //function to edit teacherPersonalData
        void editData()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXECUTE teacherEditData @nameEditData = '" + nameEditData.Text + "', @emailEditData = '" + emailEditData.Text + "', @addressEditData = '" + addressEditData.Text + "', @genderEditData = '" + isMale(genderMale.Checked) + "', @oldUsername = '" + olduserName + "'", con);
                cmd.ExecuteNonQuery();
                playSound.URL = "done.mp3";
                playSound.controls.play();
                MSBox = new MyMessageBox("Your data has been updated!");
                
            }

        }
        bool change_Pass = false, personal_Data = false;
        private void personalData_Click(object sender, EventArgs e)
        {
            personal_Data = true;
            panel3.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;
        }

        private void changePass_Click(object sender, EventArgs e)
        {
            change_Pass = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
        }
        string olduserName;
        private void doneCheckInfo_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Teacher where Name = '" + editDataCheckUsername.Text + "' and pass = '" + editDataCheckPassword.Text + "'", con); 
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    username = dr["Name"].ToString();
                    pass = dr["pass"].ToString();
                }
            }
                    using (SqlConnection con = new SqlConnection(stringConnection))
                    {
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("exec getTeacherEmail '" + editDataCheckUsername.Text + "'", con);
                        SqlDataReader dr = cmd2.ExecuteReader();
                        dr.Read();
                        teacherEmail = dr["Email"].ToString();

                    }
            
                    if(username == editDataCheckUsername.Text && pass == editDataCheckPassword.Text)
                    {
                        
                        if (change_Pass)
                        {
                             panel2.Visible = true;
                             panel3.Visible = false;
                        }else
                        {
                            panel3.Visible = false;
                            panel2.Visible = false;
                            editDataAppearance(editDataCheckUsername.Text, editDataCheckPassword.Text);
                        }
                             button5.Visible = true;
                             panel4.Visible = false;
                             button6.Visible = true;
                             button7.Visible = true;
                olduserName = editDataCheckUsername.Text;
                editDataCheckUsername.Text = editDataCheckPassword.Text = "";
                     }
            else
            {
                playSound.URL = "error.wav";
                playSound.controls.play();
                MSBox = new MyMessageBox("Wrong username or password!");
                
            }
         
            
            
        }

       

        //Function to make teacherData appears in textboxes
        void editDataAppearance(String username, String password)
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select *  from teacherEditDataAppearance ('" + editDataCheckUsername.Text + "')", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    nameEditData.Text = dr["Name"].ToString();
                    emailEditData.Text = dr["Email"].ToString();
                    addressEditData.Text = dr["Address"].ToString();
                    if(dr["Gender"].ToString() == "Male")
                    {
                        genderMale.Checked = true;
                    }
                    else
                    {
                        genderFemale.Checked = true;
                    }
                }
            }
        }
        // update Grades
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dataGridView2.Rows[e.RowIndex].Cells["Student_ID"].FormattedValue.ToString());
            float grade = float.Parse(dataGridView2[e.ColumnIndex, e.RowIndex].Value.ToString());
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Grade")
            {
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("exec updateGrades " + grade + "," + courseId() + "," + id, con);
                    SqlCommand cmd2 = new SqlCommand("exec updateStatus" , con);
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                }
            }
        }

        int courseId()
        {
            int temp = 0;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EXEC courseID '" + user_name + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    temp = Int32.Parse(dr["Course_ID"].ToString());
                }
            }
            return temp;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells["Student_ID"].FormattedValue.ToString());
            int attendance = Int32.Parse(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Attendance")
            {
                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("exec updateAttendance " + attendance + "," +courseId() + "," + id, con);
                    cmd.ExecuteNonQuery();
                }
            }

        }

       
        void showGrades()
        {
            int id = courseId();
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from showGrade(" + id + ")",con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Student_ID");
                dt.Columns.Add("Course_ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Grade");
                DataRow row;
                while(dr.Read())
                {
                    row = dt.NewRow();
                    row["Student_ID"] = dr["Student_ID"];
                    row["Course_ID"] = dr["Course_ID"];
                    row["Name"] = dr["Name"];
                    row["Grade"] = dr["Grade"];
                    dt.Rows.Add(row);
                }
                dr.Close();
                con.Close();
                dataGridView2.DataSource = dt;
                dataGridView2.BorderStyle = BorderStyle.Fixed3D;
                dataGridView2.AllowUserToResizeColumns = false;
                dataGridView2.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGridView2.AllowUserToResizeRows = false;
                dataGridView2.RowHeadersWidthSizeMode =
                    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGridView2.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView2.DefaultCellStyle.SelectionForeColor = Color.Black;
                dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                //setting color of alternating rows
                dataGridView2.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                // Specify a larger font for columns. 
                dataGridView2.DefaultCellStyle.Font = new Font("Bold Italic", 15);


            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login Lgin = new Login();
            Lgin.Show();
            this.Hide();
        }

        private void gradeNotification_Click_1(object sender, EventArgs e)
        {
            isGradenotify = true;
            isEditData = false;
            isAttendance = false;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec getParentEmail " + StudentIDNotify.Text, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                sendEmail(dr["Email"].ToString());
            }
        }
        bool isStatusNotify = false;

        private void genderMale_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            isStatusNotify = true;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec getParentEmail " + StudentIDNotify.Text, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                sendEmail(dr["Email"].ToString());
            }
        }

        private void AttendanceNotification(object sender, EventArgs e)
        {
            isAttendance = true;
            isGradenotify = false;
            isEditData = false;
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec getParentEmail " + StudentIDNotify.Text, con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                sendEmail(dr["Email"].ToString());

            }
        }

        void showAttendance()
        {
            int id = courseId();
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from showAttendance(" + id + ")", con);
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
                //setting color of alternating rows
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView1.DefaultCellStyle.Font = new Font("Bold Italic", 15);
            }
        }
        //put Student IDS in comboBox
        void showStudentIDS()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec getStudentIDS " + courseId(), con);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    StudentIDNotify.Items.Add(dr["Student_ID"]);
                }
            }
        }

 


    }
}
