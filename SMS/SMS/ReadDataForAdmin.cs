using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SMS
{
    public class ReadDataForAdmin
    {
        string stringConnection = StringConnection.ConnectionString(); 
        public Dictionary<string, List<string>> ReadTeacherTable()
        {
            var map = new Dictionary<string, List<string>>();
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Teacher", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                List<string> track = new List<string>();
                track.Add(dr["Teacher_ID"].ToString());
                track.Add(dr["Name"].ToString());
                track.Add(dr["PhoneNumber"].ToString());
                track.Add(dr["Address"].ToString());
                track.Add(dr["Email"].ToString());
                track.Add(dr["Gender"].ToString());
                track.Add(dr["Year"].ToString());
                //track.Add(dr["salary"].ToString());
                map.Add(track[1], track);
            }
            dr.Close();
            con.Close();
            return map;

        }
        public List<string> Teacherdetails(string Name)
        {
            var map = new Dictionary<string, List<string>>();
            map = ReadTeacherTable();
            List<string> s = map[Name];
            return s;
        }
        /*************************************************************/
        public Dictionary<string, List<string>> ReadParentTable()
        {
            var map = new Dictionary<string, List<string>>();
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Parent", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                List<string> track = new List<string>();
                track.Add(dr["Parent_ID"].ToString());
                track.Add(dr["Name"].ToString());
                track.Add(dr["PhoneNumber"].ToString());
                track.Add(dr["Address"].ToString());
                track.Add(dr["Email"].ToString());
                track.Add(dr["Gender"].ToString());
                track.Add(dr["Year"].ToString());
                //track.Add(dr["salary"].ToString());
                map.Add(track[0], track);
            }
            dr.Close();
            con.Close();
            return map;

        }
        public List<string> Parentdetails(string ID)
        {
            var map = new Dictionary<string, List<string>>();
            map = ReadParentTable();
            List<string> s = map[ID];
            return s;
        }
        //*************************************************************
        public Dictionary<string, List<string>> ReadStudentTable()
        {
            var map = new Dictionary<string, List<string>>();
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Student", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                List<string> track = new List<string>();
                track.Add(dr["Student_ID"].ToString());
                track.Add(dr["Name"].ToString());
                track.Add(dr["PhoneNumber"].ToString());
                track.Add(dr["Address"].ToString());
                track.Add(dr["Email"].ToString());
                track.Add(dr["Gender"].ToString());
                track.Add(dr["Year"].ToString());
                track.Add(dr["Parent_ID"].ToString());
                //track.Add(dr["salary"].ToString());
                map.Add(track[0], track);
            }
            dr.Close();
            con.Close();
            return map;

        }
        public List<string> Studentdetails(string ID)
        {
            var map = new Dictionary<string, List<string>>();
            map = ReadStudentTable();
            List<string> s = map[ID];
            return s;
        }

    }
}
