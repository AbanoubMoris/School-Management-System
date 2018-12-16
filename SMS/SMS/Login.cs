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

    public partial class Login : Form
    {
        MyMessageBox MBOX;
        //string connection thomasLaptop
        //string stringConnection = @"Data Source=DESKTOP-TIFITP1\SQLEXPRESS;Initial Catalog=Teacher;Integrated Security=True;";
        //string connection thomasPC
        //string stringConnection = @"Data Source=THOMAS-PC\SQLEXPRESS;Initial Catalog=Teacher;Integrated Security=True;";
        //Abanoub PC
        string stringConnection = StringConnection.ConnectionString();
        SmtpClient client;
        MailMessage msg;
        void sendEmailForgetPassword(string oldPass, string userEmail)
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
            msg.Subject = "Your Password";
            msg.Body = "Hi,\nYour password is: " + oldPass + " if you didn't reset your password, please change it immediately.\nRegards, SchoolSystemTeam.";
            client.Send(msg);
            MessageBox.Show("An Email With Your Password Has Been Sent!");
        }
        

        bool strongPass = false, correctPhone = false, validMail = false;
        bool ChoosedAdmin = false;
        bool ChoosedTeacher = false;
        bool ChoosedStudent = false;
        bool ChoosedParent = false;
        public Login()
        {
            InitializeComponent();
            ChoosePanel.Visible = true;
            panel1.Visible = false;
        }

        private void SignupPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
            ChoosePanel.Visible = false;
            LoginPanel.Visible = false;
            panel1.Visible = false;
            SignupPanel.Visible = true;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            ChoosedAdmin = true;
            ChoosePanel.Visible = false;
            SignupPanel.Visible = false;
            panel1.Visible = false;
            LoginPanel.Visible = true;
            label6.Hide();
            courseYouTeachReg.Hide();
            femaleReg.Location = new Point(245, 330);
            maleReg.Location = new Point(132, 330);
            label2.Location = new Point(9, 330);
            label3.Location = new Point(90, 330);
            label4.Location = new Point(177, 330);
            label5.Location = new Point(9, 277);
            dayReg.Location = new Point(84, 265);
            monthReg.Location = new Point(171, 265);
            yearReg.Location = new Point(258, 265);
            bunifuCustomLabel2.Hide();
        }
        bool teacherIsClicked = false;
        bool studentIsClicked = false;
        bool parentIsClicked = false;

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            teacherIsClicked = true;
            ChoosedTeacher = true;
            ChoosePanel.Visible = false;
            SignupPanel.Visible = false;
            panel1.Visible = false;
            LoginPanel.Visible = true;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            studentIsClicked = true;
            ChoosedStudent = true;
            ChoosePanel.Visible = false;
            SignupPanel.Visible = false;
            panel1.Visible = false;
            LoginPanel.Visible = true;
            label6.Hide();
            courseYouTeachReg.Hide();
            femaleReg.Location = new Point(245, 330);
            maleReg.Location = new Point(132, 330);
            label2.Location = new Point(9, 330);
            label3.Location = new Point(90, 330);
            label4.Location = new Point(177, 330);
            label5.Location = new Point(9, 277);
            dayReg.Location = new Point(84, 265);
            monthReg.Location = new Point(171, 265);
            yearReg.Location = new Point(258, 265);
            bunifuCustomLabel2.Visible = false;

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            parentIsClicked = true;
            ChoosedParent = true;
            ChoosePanel.Visible = false;
            SignupPanel.Visible = false;
            panel1.Visible = false;
            LoginPanel.Visible = true;
            label6.Hide();
            courseYouTeachReg.Hide();
            femaleReg.Location = new Point(245, 330);
            maleReg.Location = new Point(132, 330);
            label2.Location = new Point(9, 330);
            label3.Location = new Point(90, 330);
            label4.Location = new Point(177, 330);
            label5.Location = new Point(9, 277);
            dayReg.Location = new Point(84, 265);
            monthReg.Location = new Point(171, 265);
            yearReg.Location = new Point(258, 265);
         
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (ChoosedTeacher)
            {
                login("Teacher");
            }
            else if (ChoosedStudent)
            {
                login("Student");
            }
            else if (ChoosedParent)
            {
                login("Parent");
            }
            else login("");
        }

        void login(string tableName)
        {
            if (ChoosedAdmin)
            {
                this.Hide();
                if ((bunifuMetroTextbox2.Text = bunifuMetroTextbox1.Text) == "Admin")
                {
                    MBOX = new MyMessageBox("Welcome Admin!");
                    var singleton = Singleton.Instance;
                    var f = singleton.AdminForm;
                    f.Show();
                    //Admin Ad = new Admin();
                    //Ad.Show();
                }
                else
                {
                    MBOX = new MyMessageBox("Wrong UserName Or Password !");
                    Login LOG = new Login();
                    LOG.ShowDialog();
                }
            }
            else
            {


                bool login = false;
                if (bunifuMetroTextbox2.Text == "" || bunifuMetroTextbox1.Text == "")
                {
                    MBOX = new MyMessageBox("You can't leave anything empty!");
                   
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(stringConnection))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select * from " + tableName, con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            string username = dr["Name"].ToString();
                            string pass = dr["pass"].ToString();
                            if (bunifuMetroTextbox2.Text == username && bunifuMetroTextbox1.Text == pass)
                            {

                                this.Hide();
                                login = true;
                                MBOX = new MyMessageBox("Welcome " + username + '!');
                                
                                if (ChoosedTeacher)
                                {
                                    Teachers_Form Ta = new Teachers_Form(username);
                                    Ta.Show();
                                }
                                else if (ChoosedParent)
                                {
                                    Parent Pa = new Parent(username);
                                    Pa.Show();
                                }
                                else if (ChoosedStudent)
                                {
                                    Student_Form Sa = new Student_Form(username);
                                    Sa.Show();
                                }
                                break;
                            }

                        }
                        
                       
                 
                        if (!login) MBOX = new MyMessageBox("Wrong username or password!");
                        bunifuMetroTextbox2.Text = bunifuMetroTextbox1.Text = "";
                    }
                }
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
            
            //register
            if (teacherIsClicked) register("Teacher");
            else register("Parent");
       }
       

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            ChoosePanel.Visible = false;
            SignupPanel.Visible = false;
            LoginPanel.Visible = false;
            usernameReg.Text = "USERNAME";
            emailReg.Text = "EMAIL";
            mobileReg.Text = "MOBILE";
            addressReg.Text = "ADDRESS";
            passReg.Text = "PASSWORD";
            dayReg.Text = "DAY";
            monthReg.Text = "MONTH";
            yearReg.Text = "YEAR";
        }
        string oldPass;
        void forgetPass(string tableName)
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from " + tableName + " where Name = '" + bunifuMetroTextbox13.Text + "' and Email = '" + bunifuMetroTextbox12.Text + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oldPass = dr["pass"].ToString();
                }

            }
            sendEmailForgetPassword(oldPass, bunifuMetroTextbox12.Text);
        }
        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            if (teacherIsClicked) forgetPass("Teacher");
            else if (studentIsClicked) forgetPass("Student");
            else if(parentIsClicked) forgetPass("Parent");
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Textboxes Hint
        private void bunifuMetroTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "USERNAME")
            {
                bunifuMetroTextbox2.Text = "";
                bunifuMetroTextbox2.ForeColor = Color.White;
                usernameReg.ForeColor = Color.White;
            }
        }

        private void bunifuMetroTextbox2_Leave(object sender, EventArgs e)
        {
            if(bunifuMetroTextbox2.Text == "")
            {
            bunifuMetroTextbox2.Text = "USERNAME";
            bunifuMetroTextbox2.ForeColor = Color.Gray;
            }
        }

        private void bunifuMetroTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "PASSWORD")
            {
                bunifuMetroTextbox1.ForeColor = Color.White;
                bunifuMetroTextbox1.Text = "";
            }
        }

        private void bunifuMetroTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox1.Text == "")
            {
                bunifuMetroTextbox1.Text = "PASSWORD";
                bunifuMetroTextbox1.ForeColor = Color.Gray;
            }
        }

        private void bunifuMetroTextbox13_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox13.Text == "USERNAME")
            {
                bunifuMetroTextbox13.Text = "";
                bunifuMetroTextbox13.ForeColor = Color.White;
            }
        }

        private void bunifuMetroTextbox13_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox13.Text == "")
            {
                bunifuMetroTextbox13.Text = "USERNAME";
                bunifuMetroTextbox13.ForeColor = Color.Gray;
            }
        }

        private void bunifuMetroTextbox12_Enter(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox12.Text == "MAIL")
            {
                bunifuMetroTextbox12.Text = "";
                bunifuMetroTextbox12.ForeColor = Color.White;
            }
        }

        private void bunifuMetroTextbox12_Leave(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox12.Text == "")
            {
                bunifuMetroTextbox12.Text = "MAIL";
                bunifuMetroTextbox12.ForeColor = Color.Gray;
            }
        }

        private void bunifuMetroTextbox3_Enter(object sender, EventArgs e)
        {
            if (usernameReg.Text == "Name")
            {
                usernameReg.Text = "";
                bunifuMetroTextbox12.ForeColor = Color.White;
            }
        }

        private void bunifuMetroTextbox3_Leave(object sender, EventArgs e)
        {
            if (usernameReg.Text == "")
            {
                usernameReg.Text = "Name";
                bunifuMetroTextbox12.ForeColor = Color.Gray;
            }
        }

        private void bunifuMetroTextbox5_Enter(object sender, EventArgs e)
        {
            if (emailReg.Text == "Email Address")
            {
                emailReg.ForeColor = Color.White;
                emailReg.Text = "";
            }
        }

        private void bunifuMetroTextbox5_Leave(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox6_Enter(object sender, EventArgs e)
        {
            if (passReg.Text == "Password")
            {
                passReg.ForeColor = Color.White;
                passReg.Text = "";
            }
        }

        private void bunifuMetroTextbox6_Leave(object sender, EventArgs e)
        {
            if (passReg.Text == "")
            {
                passReg.ForeColor = Color.Gray;
                passReg.Text = "Password";
            }
        }

        private void bunifuMetroTextbox7_Enter(object sender, EventArgs e)
        {
            if (mobileReg.Text == "Mobile Number")
            {
                mobileReg.ForeColor = Color.White;
                mobileReg.Text = "";
            }
        }

        private void bunifuMetroTextbox7_Leave(object sender, EventArgs e)
        {
            if (mobileReg.Text == "")
            {
                mobileReg.ForeColor = Color.Gray;
                mobileReg.Text = "Mobile Number";
            }
        }

        private void bunifuMetroTextbox8_Enter(object sender, EventArgs e)
        {
            if (addressReg.Text == "Address")
            {
                addressReg.ForeColor = Color.White;
                addressReg.Text = "";
            }
        }

        private void bunifuMetroTextbox8_Leave(object sender, EventArgs e)
        {
            if (addressReg.Text == "")
            {
                addressReg.ForeColor = Color.Gray;
                addressReg.Text = "Address";
            }
        }

        private void bunifuMetroTextbox9_Enter(object sender, EventArgs e)
        {
            if (dayReg.Text == "DAY")
            {
                dayReg.ForeColor = Color.White;
                dayReg.Text = "";
            }
        }

        private void bunifuMetroTextbox9_Leave(object sender, EventArgs e)
        {
            if (dayReg.Text == "")
            {
                dayReg.ForeColor = Color.Gray;
                dayReg.Text = "DAY";
            }
        }

        private void bunifuMetroTextbox10_Enter(object sender, EventArgs e)
        {
            if (monthReg.Text == "MONTH")
            {
                monthReg.ForeColor = Color.White;
                monthReg.Text = "";
            }
        }

        private void bunifuMetroTextbox10_Leave(object sender, EventArgs e)
        {
            if (monthReg.Text == "")
            {
                monthReg.ForeColor = Color.Gray;
                monthReg.Text = "MONTH";
            }
        }

        private void bunifuMetroTextbox11_Enter(object sender, EventArgs e)
        {
            if (yearReg.Text == "YEAR")
            {
                yearReg.ForeColor = Color.White;
                yearReg.Text = "";
            }
        }

        private void bunifuMetroTextbox11_Leave(object sender, EventArgs e)
        {
            if (yearReg.Text == "")
            {
                yearReg.ForeColor = Color.Gray;
                yearReg.Text = "YEAR";
            }
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (femaleReg.Checked) femaleReg.Checked = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (maleReg.Checked) maleReg.Checked = false;

        }

        String checkGender(bool isMale)
        {
            return isMale == true ? "Male" : "Female";
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = true;
            panel1.Visible = false;
        }

        private void back_Click(object sender, EventArgs e)
        {
            Login lgin = new Login();
            lgin.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            LoginPanel.Visible = true;
            SignupPanel.Visible = false;
        }

        bool usernameExists = false;

        //register fn
       void register(string tableName)
        {
            strongPass = false;
            correctPhone = false;
            validMail = false;
            usernameExists = false;
            if (usernameReg.Text == "" || passReg.Text == "" || addressReg.Text == "" || mobileReg.Text == "" || emailReg.Text == "" || dayReg.Text=="" || monthReg.Text=="" || yearReg.Text=="")
            {
                if (ChoosedTeacher) 
                {
                    if (courseYouTeachReg.Text == "") MBOX = new MyMessageBox("Please dont leave anything blank!");
                }
                else
                {
                    MBOX = new MyMessageBox("Please dont leave anything blank!");
                }
            }
            else
            {
                if (passReg.Text.Count() < 6)
                {

                   MBOX = new MyMessageBox ("Please Enter stronger password");

                }
                else strongPass = true; 

                if (mobileReg.Text.Count() != 11) MBOX = new MyMessageBox("Please make sure you entered 11 numbers in your phone!");
                else correctPhone = true;


                if (strongPass && correctPhone)
                {
                    using (SqlConnection con = new SqlConnection(stringConnection))
                    {
                        con.Open();
                        using (SqlCommand c1 = new SqlCommand("select * from " + tableName, con))
                        {
                            SqlDataReader dr = c1.ExecuteReader();
                            while (dr.Read())
                            {
                                if (dr["Name"].ToString() == usernameReg.Text)
                                {
                                    usernameExists = true;
                                    break;
                                }
                            }
                            dr.Close();
                        }
                        if (!usernameExists)
                        {
                            SqlCommand cmd = new SqlCommand("insert into " + tableName + "(Name,pass,PhoneNumber,Address,Email,Gender,Day,Month,Year) values ('" + usernameReg.Text + "','" + passReg.Text + "'," + mobileReg.Text + ",'" + addressReg.Text + "','" + emailReg.Text + "','" + checkGender(maleReg.Checked) + "'," + dayReg.Text + "," + monthReg.Text + "," + yearReg.Text + ");", con);
                            if (teacherIsClicked)
                            {
                                SqlCommand c = new SqlCommand("insert into Course (Course_Name) values ('" + courseYouTeachReg.Text + "')", con);
                                c.ExecuteNonQuery();
                            }
                            cmd.ExecuteNonQuery();
                            MBOX = new MyMessageBox("Registered Successfully!");
                           
                            ChoosePanel.Visible = false;
                            SignupPanel.Visible = false;
                            panel1.Visible = false;
                            LoginPanel.Visible = false;
                            LoginPanel.Visible = true;
                            usernameReg.Text = passReg.Text = addressReg.Text = emailReg.Text = dayReg.Text = monthReg.Text = yearReg.Text = mobileReg.Text = courseYouTeachReg.Text ="";
                            maleReg.Checked = false;
                            femaleReg.Checked = false;
                        }else
                        {
                            MBOX = new MyMessageBox("Username Exists, Please choose another one!");
                       
                        }

                    }
                }
            }
        }
    }
    
}
