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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
            dgvEmployeeDetails.DataSource = ec.getEmplopyees();
        }
        String gender;
        int EmployeeID;
        Database.EmployeeClass ec = new Database.EmployeeClass();

        private void EmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = ec.manageEmployee(EmployeeID,
                    txtEmployeeName.Text,
                    txtAddress.Text,
                    txtContact.Text,
                    gender,
                    txtEmail.Text,
                    DateTime.Parse(dtpDOB.Text),
                    txtDepartment.Text,
                    txtDesignation.Text, 2);
                if (rs == true)
                {
                    MessageBox.Show("Employee Successfully Updated");
                    dgvEmployeeDetails.DataSource = ec.getEmplopyees();
                    helperClass.makeFieldsBlank(groupBox1);
                    rdbFemale.Checked = false;
                    rdbMale.Checked = false;
                    rdbOther.Checked = false;
                }
                else
                {
                    MessageBox.Show("Error in performing the required operation");
                    helperClass.makeFieldsBlank(groupBox1);
                    rdbFemale.Checked = false;
                    rdbMale.Checked = false;
                    rdbOther.Checked = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void rdbOther_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Other";
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = ec.manageEmployee(EmployeeID,
                    txtEmployeeName.Text,
                    txtAddress.Text,
                    txtContact.Text,
                    gender, 
                    txtEmail.Text,
                    DateTime.Parse(dtpDOB.Text),
                    txtDepartment.Text,
                    txtDesignation.Text, 1);
                if(rs==true)
                {
                    MessageBox.Show("Employee Successfully Added");
                    dgvEmployeeDetails.DataSource = ec.getEmplopyees();
                    helperClass.makeFieldsBlank(groupBox1);
                    rdbFemale.Checked = false;
                    rdbMale.Checked = false;
                    rdbOther.Checked = false;

                }
                else
                {
                    MessageBox.Show("Error in performing the required operation");
                    helperClass.makeFieldsBlank(groupBox1);
                    rdbFemale.Checked = false;
                    rdbMale.Checked = false;
                    rdbOther.Checked = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvEmployeeDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeID = int.Parse(dgvEmployeeDetails.SelectedRows[0].Cells["employeeid"].Value.ToString());
            txtEmployeeName.Text = dgvEmployeeDetails.SelectedRows[0].Cells["employeeName"].Value.ToString();
            txtAddress.Text = dgvEmployeeDetails.SelectedRows[0].Cells["address"].Value.ToString();
            txtContact.Text = dgvEmployeeDetails.SelectedRows[0].Cells["contact"].Value.ToString();
            gender = dgvEmployeeDetails.SelectedRows[0].Cells["gender"].Value.ToString();
            txtEmail.Text = dgvEmployeeDetails.SelectedRows[0].Cells["email"].Value.ToString();
            dtpDOB.Text = dgvEmployeeDetails.SelectedRows[0].Cells["dateofbirth"].Value.ToString();
            txtDepartment.Text = dgvEmployeeDetails.SelectedRows[0].Cells["department"].Value.ToString();
            txtDesignation.Text = dgvEmployeeDetails.SelectedRows[0].Cells["designation"].Value.ToString();
            if (gender == "Male")
                rdbMale.Checked = true;
            else if (gender == "Female")
                rdbFemale.Checked = true;
            else if (gender == "Other")
                rdbOther.Checked = true;
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = ec.manageEmployee(EmployeeID,
                    txtEmployeeName.Text,
                    txtAddress.Text,
                    txtContact.Text,
                    gender,
                    txtEmail.Text,
                    DateTime.Parse(dtpDOB.Text),
                    txtDepartment.Text,
                    txtDesignation.Text, 3);
                if (rs == true)
                {
                    MessageBox.Show("Employee Successfully Deleted");
                    dgvEmployeeDetails.DataSource = ec.getEmplopyees();
                    helperClass.makeFieldsBlank(groupBox1);
                    rdbFemale.Checked = false;
                    rdbMale.Checked = false;
                    rdbOther.Checked = false;
                }
                else
                {
                    MessageBox.Show("Error in performing the required operation");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
