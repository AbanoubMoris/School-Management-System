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

namespace SMS
{
    public partial class Parent : Form
    {
        MyMessageBox MSBOX;
        string stringConnection = StringConnection.ConnectionString();
        string parent_name;
        public Parent(String parentName)
        {
            InitializeComponent();
            parent_name = parentName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QueryPanel.Visible = false;
            StuPanel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StuPanel.Visible = false;
            QueryPanel.Visible = true;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            selectTeacherPanel.Visible = false;
            sendEmailPanel.Visible = false;
            showChildrensNames();
            showTeacherContactInfo();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool usernameExists = false , strongPass = false, correctPhone = false;

        private void label4_Click(object sender, EventArgs e)
        {
            register();
        }

        String checkGender(bool isMale)
        {
            return isMale == true ? "Male" : "Female";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectTeacherPanel.Visible = true;
            dataGridView2.Visible = false;
            comboBox1.Visible = true;
            dataGridView1.Visible = true;
            sendEmailPanel.Visible = false;
        }

        //assign student
        void register()
        {
            strongPass = false;
            correctPhone = false;
            usernameExists = false;
            if (studentName.Text == "" || studentPass.Text == "" || studentAddress.Text == "" || studentPhone.Text == "" || studentEmail.Text == "" || dayReg.Text == "" || monthReg.Text == "" || yearReg.Text == "")
            {
                MSBOX = new MyMessageBox("Please dont leave anything blank!");
                  
                
            }
            else
            {
                if (studentPass.Text.Count() < 6)
                {

                     MSBOX = new MyMessageBox("Please Enter stronger password");
                    /***********************************************************************/
                }
                else strongPass = true; 

                if (studentPhone.Text.Count() != 11) MSBOX = new MyMessageBox("Please Enter stronger password");
                else correctPhone = true;


                if (strongPass && correctPhone)
                {
                    using (SqlConnection con = new SqlConnection(stringConnection))
                    {
                        con.Open();
                        using (SqlCommand c1 = new SqlCommand("select * from Student", con))
                        {
                            SqlDataReader dr = c1.ExecuteReader();
                            while (dr.Read())
                            {
                                if (dr["Name"].ToString() == studentName.Text)
                                {
                                    usernameExists = true;
                                    break;
                                }
                            }
                            dr.Close();
                        }
                        int parentId = 0;
                        using (SqlCommand c2 = new SqlCommand("exec getParentID '" + parent_name + "'", con))
                        {
                            SqlDataReader dr = c2.ExecuteReader();
                            dr.Read();
                            parentId = Int32.Parse(dr["Parent_ID"].ToString());
                            dr.Close();
                        }
                            if (!usernameExists)
                            {
                                SqlCommand cmd = new SqlCommand("insert into Student (Name,pass,PhoneNumber,Address,Email,Gender,Day,Month,Year,Parent_ID) values ('" + studentName.Text + "','" + studentPass.Text + "'," + studentPhone.Text + ",'" + studentAddress.Text + "','" + studentEmail.Text + "','" + checkGender(maleCheckBox.Checked) + "'," + dayReg.Text + "," + monthReg.Text + "," + yearReg.Text + "," + parentId +");", con);
                                cmd.ExecuteNonQuery();
                                MSBOX = new MyMessageBox("Registered Successfully!");
                                studentName.Text = studentPass.Text = studentAddress.Text = studentEmail.Text = dayReg.Text = monthReg.Text = yearReg.Text = studentPhone.Text = "";
                                maleCheckBox.Checked = false;
                                femaleCheckBox.Checked = false;
                            }
                            else
                            {
                            MSBOX = new MyMessageBox("Username Exists,Please choose another one!");
                         
                            }

                    }
                }
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            showStudentGrades();
        }

        //show studentGrades
        void showStudentGrades()
        {
            string childName = "";
            if (comboBox1.Text != "")
            {
                childName = comboBox1.Text;

                using (SqlConnection con = new SqlConnection(stringConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from showGradeInAllCourses('" + parent_name + "','" + childName + "')", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Stud_ID");
                    dt.Columns.Add("Course_ID");
                    dt.Columns.Add("Course_Name");
                    dt.Columns.Add("Grade");
                    DataRow row;
                    while (dr.Read())
                    {
                        row = dt.NewRow();
                        row["Stud_ID"] = dr["Stud_ID"];
                        row["Course_ID"] = dr["Course_ID"];
                        row["Grade"] = dr["Grade"];
                        row["Course_Name"] = dr["Course_Name"];
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
                    dataGridView1.DefaultCellStyle.Font = new Font("Bold Italic", 11);


                }
            }
        }

        //show Teacher Info
        void showTeacherContactInfo()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec showTeacherContactInfo" , con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("Teacher_Name");
                dt.Columns.Add("Course_Name");
                dt.Columns.Add("Phone_Number");
                dt.Columns.Add("Address");
                dt.Columns.Add("Email");
                DataRow row;
                while (dr.Read())
                {
                    row = dt.NewRow();
                    row["Teacher_Name"] = dr["Name"];
                    row["Course_Name"] = dr["Course_Name"];
                    row["Phone_Number"] = dr["PhoneNumber"];
                    row["Address"] = dr["Address"];
                    row["Email"] = dr["Email"];
                    dt.Rows.Add(row);
                }
                dr.Close();
                con.Close();
                dataGridView2.DataSource = dt;
                dataGridView2.BorderStyle = BorderStyle.Fixed3D;
                dataGridView2.AllowUserToResizeColumns = true;
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
                dataGridView2.DefaultCellStyle.Font = new Font("Bold Italic", 11);
            }
            
        }

        int parentID = 0;

        private void dayReg_Enter(object sender, EventArgs e)
        {
            if (dayReg.Text == "DAY")
            {
                dayReg.ForeColor = Color.Black;
                dayReg.Text = "";
            }
        }

        private void dayReg_Leave(object sender, EventArgs e)
        {
            if (dayReg.Text == "")
            {
                dayReg.ForeColor = Color.Gray;
                dayReg.Text = "DAY";
            }
        }
        //****************************************************
        private void monthReg_Enter(object sender, EventArgs e)
        {
            if (monthReg.Text == "MONTH")
            {
                monthReg.ForeColor = Color.Black;
                monthReg.Text = "";
            }
        }

        private void monthReg_Leave(object sender, EventArgs e)
        {
            if (monthReg.Text == "")
            {
                monthReg.ForeColor = Color.Gray;
                monthReg.Text = "MONTH";
            }
        }
        //*************************************************
        //****************************************************
        private void yearReg_Enter(object sender, EventArgs e)
        {
            if (yearReg.Text == "YEAR")
            {
                yearReg.ForeColor = Color.Black;
                yearReg.Text = "";
            }
        }

        private void yearReg_Leave(object sender, EventArgs e)
        {
            if (yearReg.Text == "")
            {
                yearReg.ForeColor = Color.Gray;
                yearReg.Text = "YEAR";
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login Lgin = new Login();
            Lgin.Show();
            this.Hide();
        }

        // Contact Teacher Button
        private void button4_Click(object sender, EventArgs e)
        {
            selectTeacherPanel.Visible = true;
            dataGridView2.Visible = true;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
            sendEmailPanel.Visible = false;
            showTeacherContactInfo();
        }

        void getParentID()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("exec getParentID '" + parent_name + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                parentID = Int32.Parse(dr["Parent_ID"].ToString());
                dr.Close();

            }
        }

       

        private void textLocalPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void liveSupportButton_Click(object sender, EventArgs e)
        {
            sendEmailPanel.Visible = false;
            selectTeacherPanel.Visible = true;
            dataGridView2.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
        }

        void showChildrensNames()
        {
            getParentID();
                if (comboBox1.Items.Count == 0)
                {
                    using (SqlConnection con = new SqlConnection(stringConnection))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select distinct Name from showChildrenNames (" + parentID + ")", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr["Name"]);
                        }
                        dr.Close();
                        
                    }
                }
        }


        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            selectTeacherPanel.Visible = false;
            dataGridView2.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = false;
            sendEmailPanel.Visible = true;
        }

        // Sending Email to Teacher button
        private void sendEmailbtn_Click(object sender, EventArgs e)
        {
            sendEmailContactTeacher(toTextBox.Text, fromTextBox.Text, subjectTextBox.Text, messageTextBox.Text);
        }

        // Sending email to Contact Teacher
        SmtpClient client2;
        MailMessage msg2;
        void sendEmailContactTeacher(string to, string from, string subject , string message)
        {
            client2 = new SmtpClient();
            msg2 = new MailMessage();
            client2.Port = 587;
            client2.Host = "smtp.gmail.com";
            client2.EnableSsl = true;
            client2.Timeout = 10000;
            client2.DeliveryMethod = SmtpDeliveryMethod.Network;
            client2.UseDefaultCredentials = false;
            client2.Credentials = new System.Net.NetworkCredential("schoolsystem21@gmail.com", "Fcis2021");
            msg2.From = new MailAddress("schoolsystem21@gmail.com");
            msg2.To.Add(new MailAddress(to));
            msg2.Subject = subject;
            msg2.Body = message + "\n\nSent by Parent: " + parent_name + "\nParent's Email Address: " + from;
            client2.Send(msg2);
            MessageBox.Show("Your Email Has Been Sent Successfully!");
        }

    }
}
