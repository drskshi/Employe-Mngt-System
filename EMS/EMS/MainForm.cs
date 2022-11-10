using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblDateTime.Text = DateTime.Now.ToString(); dgvEmployeeDetails.DataSource = ec.getEmplopyees();
        }
        Database.EmployeeClass ec = new Database.EmployeeClass();

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Form frm = new User_Form();
            frm.ShowDialog();   
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeForm frm = new EmployeeForm();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            dgvEmployeeDetails.DataSource = ec.getEmployeeByName(txtEmployeeName.Text); 
        }
    }
}
