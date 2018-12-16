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

namespace SMS
{
    class AdminFunctions
    {

        string stringConnection = StringConnection.ConnectionString(); 

        public void TeacherData(Panel TPanel)
        {
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("exec TeacherNameAndCourse ", con);
            cmd.ExecuteNonQuery();
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            int location = 0;
            while (dr.Read())
            {
                Teachers Te = new Teachers();
                string s = dr["Name"].ToString();
                string x = dr["Course_Name"].ToString();
                Te.TeacherName.Text = s;
                Te.TeacherSubject.Text = x;
                Te.Location = new Point(7, location + 5);
                location += Te.Height + 5;
                Te.Name = "Teacher";
                TPanel.Controls.Add(Te);
            }
            dr.Close();
            con.Close();
        }

        public void ParentData(Panel PPanel)
        {
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name,Parent_ID from Parent ", con);

            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            int location = 0;
            while (dr.Read())
            {
                Teachers Te = new Teachers();

                Te.TeacherName.Text = dr["Name"].ToString();
                Te.TeacherSubject.Text = dr["Parent_ID"].ToString();

                Te.Location = new Point(0, location + 5);
                location += Te.Height + 5;
                Te.Name = "Parent";
                PPanel.Controls.Add(Te);
            }
            dr.Close();
            con.Close();
        }

        public void StudentData(Panel SPanel)
        {
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name,Student_ID from Student ", con);

            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            int location = 0;
            while (dr.Read())
            {
                Teachers Te = new Teachers();

                Te.TeacherName.Text = dr["Name"].ToString();
                Te.TeacherSubject.Text = dr["Student_ID"].ToString();

                Te.Location = new Point(0, location + 5);
                location += Te.Height + 5;
                Te.Name = "Student";
                SPanel.Controls.Add(Te);
            }
            dr.Close();
            con.Close();
        }
    }
}
