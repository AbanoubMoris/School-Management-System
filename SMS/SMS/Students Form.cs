using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class Students_Form : Form
    {
        public Students_Form()
        {
            InitializeComponent();
           
        }

        private void Students_Form_Load(object sender, EventArgs e)
        {
            ExitPic.BackColor = Color.Transparent;
            Welcome_label.BackColor = Color.Transparent;
            click_label.BackColor = Color.Transparent;
            Personal_pnl.Visible = false;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            buttoms_pnl.Visible = false;
            courses_pnl.Visible = false;
            EditData_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
        }

        private void Welcome_label_Click(object sender, EventArgs e)
        {

        }

        private void click_label_Click(object sender, EventArgs e)
        {
            click_label.ForeColor = Color.Red;
            buttoms_pnl.Visible = true;
            ExitPic.Visible = true;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            courses_pnl.Visible = false;
            EditData_pnl.Visible = false;
            grades_pnl.Visible = false;
            Personal_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;

        }

        private void ShowCourses_btn_Click(object sender, EventArgs e)
        {
            ShowCourses_pnl.Visible = true;
            click_label.Visible = false;
            Welcome_label.Visible = false;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            buttoms_pnl.Visible = false;
            courses_pnl.Visible = false;
            EditData_pnl.Visible = false;
            grades_pnl.Visible = false;
            Personal_pnl.Visible = false;
            status_pnl.Visible = false;
        }


        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void ExitPic_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
        private void Done_lbl_Click(object sender, EventArgs e)
        {
            ExitPic.Visible = true;
            buttoms_pnl.Visible = true;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            courses_pnl.Visible = false;
            EditData_pnl.Visible = false;
            grades_pnl.Visible = false;
            Personal_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
            click_label.Visible = false;
            Welcome_label.Visible = false;
        }
        
        private void UandP_btn_Click(object sender, EventArgs e)
        {
            EditUandP_pnl.Visible = true;
            attendance_pnl.Visible=false;
            buttoms_pnl.Visible=false;
            courses_pnl.Visible=false;
            EditData_pnl.Visible=false;
            grades_pnl.Visible=false;
            Personal_pnl.Visible=false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
            click_label.Visible = false;
            Welcome_label.Visible = false;

        }

        private void personal_btn_Click(object sender, EventArgs e)
        {
            Personal_pnl.Visible = true;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            buttoms_pnl.Visible = false;
            courses_pnl.Visible = false;
            EditData_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
            click_label.Visible = false;
            Welcome_label.Visible = false;
        }

        private void EditData_btn_Click(object sender, EventArgs e)
        {
            EditData_pnl.Visible = true;
            Personal_pnl.Visible = false;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            buttoms_pnl.Visible = false;
            courses_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
            click_label.Visible = false;
            Welcome_label.Visible = false;
        }

        private void Showgrades_btn_Click(object sender, EventArgs e)
        {
            grades_pnl.Visible = true;
            Personal_pnl.Visible = false;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            buttoms_pnl.Visible = false;
            courses_pnl.Visible = false;
            EditData_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
            click_label.Visible = false;
            Welcome_label.Visible = false;
        }

        private void Attendance_btn_Click(object sender, EventArgs e)
        {
            attendance_pnl.Visible = true;
            Personal_pnl.Visible = false;
            EditUandP_pnl.Visible = false;
            buttoms_pnl.Visible = false;
            courses_pnl.Visible = false;
            EditData_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
            click_label.Visible = false;
            Welcome_label.Visible = false;
        }

        private void Status_btn_Click_1(object sender, EventArgs e)
        {
            status_pnl.Visible = true;
            Personal_pnl.Visible = false;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            buttoms_pnl.Visible = false;
            courses_pnl.Visible = false;
            EditData_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            click_label.Visible = false;
            Welcome_label.Visible = false;
        }

        private void Choosecourses_btn_Click(object sender, EventArgs e)
        {
            courses_pnl.Visible = true;
            Personal_pnl.Visible = false;
            EditUandP_pnl.Visible = false;
            attendance_pnl.Visible = false;
            buttoms_pnl.Visible = false;
            EditData_pnl.Visible = false;
            grades_pnl.Visible = false;
            ShowCourses_pnl.Visible = false;
            status_pnl.Visible = false;
            click_label.Visible = false;
            Welcome_label.Visible = false;
        }
    }
}
