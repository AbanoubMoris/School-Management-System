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
    public partial class TeachersForm : Form
    {
        public TeachersForm()
        {
            InitializeComponent();
        }
        
        private void TeachersForm_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            click_lbl.BackColor = Color.Transparent;
            buttoms_pnl.Visible = false;
            EditData_pnl.Visible = false;
            personalData_pnl.Visible = false;
            changepass_pnl.Visible = false;
            notify_pnl.Visible = false;
            addgrades_pnl.Visible = false;
            addAttend_pnl.Visible = false;
            
        }
        private void click_lbl_Click(object sender, EventArgs e)

        {
            Edit_data_label.BackColor = Color.Transparent;
            grades_label.BackColor = Color.Transparent;
            notify_label.BackColor = Color.Transparent;
            attendance_label.BackColor = Color.Transparent;
            Exitpic.BackColor = Color.Transparent;
            label1.Visible = false;
            click_lbl.Visible = false;
            click_lbl.ForeColor = Color.Red;
            buttoms_pnl.Visible = true;
            EditData_pnl.Visible = false;
            personalData_pnl.Visible = false;
            changepass_pnl.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void back_label_Click(object sender, EventArgs e)
        {
            buttoms_pnl.Visible = false;
            EditData_pnl.Visible = true;
            personalData_pnl.Visible = false;
            changepass_pnl.Visible = false;
            notify_pnl.Visible = false;
            addgrades_pnl.Visible = false;
            addAttend_pnl.Visible = false;
        }

        private void Done_lbl_Click(object sender, EventArgs e)
        {
            buttoms_pnl.Visible = true;
            EditData_pnl.Visible = false;
            personalData_pnl.Visible = false;
            changepass_pnl.Visible = false;
            notify_pnl.Visible = false;
            addgrades_pnl.Visible = false;
            addAttend_pnl.Visible = false;

        }

        private void personalData_Click(object sender, EventArgs e)
        {
            personalData_pnl.Visible = true;
            buttoms_pnl.Visible = false;
            EditData_pnl.Visible = false;
           
            changepass_pnl.Visible = false;
            notify_pnl.Visible = false;
            addgrades_pnl.Visible = false;
            addAttend_pnl.Visible = false;
        }

        private void changepass_Click(object sender, EventArgs e)
        {
            changepass_pnl.Visible = true;
            buttoms_pnl.Visible = false;
            EditData_pnl.Visible = false;
            personalData_pnl.Visible = false;
           
            notify_pnl.Visible = false;
            addgrades_pnl.Visible = false;
            addAttend_pnl.Visible = false;
        }

        private void data_btn_Click(object sender, EventArgs e)
        {
            EditData_pnl.Visible = true;
            buttoms_pnl.Visible = false;
               
            personalData_pnl.Visible = false;
            changepass_pnl.Visible = false;
            notify_pnl.Visible = false;
            addgrades_pnl.Visible = false;
            addAttend_pnl.Visible = false;
        }

        private void grades_btn_Click(object sender, EventArgs e)
        {
            addgrades_pnl.Visible = true;
            buttoms_pnl.Visible = false;
            EditData_pnl.Visible = false;
            personalData_pnl.Visible = false;
            changepass_pnl.Visible = false;
            notify_pnl.Visible = false;
           
            addAttend_pnl.Visible = false;
        }

        private void atten_btn_Click(object sender, EventArgs e)
        {
            addAttend_pnl.Visible = true;
            buttoms_pnl.Visible = false;
            EditData_pnl.Visible = false;
            personalData_pnl.Visible = false;
            changepass_pnl.Visible = false;
            notify_pnl.Visible = false;
            addgrades_pnl.Visible = false;
           
        }

        private void notify_btn_Click(object sender, EventArgs e)
        {
            notify_pnl.Visible = true;
            buttoms_pnl.Visible = false;
            EditData_pnl.Visible = false;
            personalData_pnl.Visible = false;
            changepass_pnl.Visible = false;
           
            addgrades_pnl.Visible = false;
            addAttend_pnl.Visible = false;
        }

        
        
    }
}
