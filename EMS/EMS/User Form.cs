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
    public partial class User_Form : Form
    {
        public User_Form()
        {
            InitializeComponent();
            dgvUserDetails.DataSource = uc.getUsers();
        }
        Database.UserClass uc = new Database.UserClass();

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = uc.manageUsers(UserID, txtUsername.Text, txtPassword.Text, 2);
                if (rs == true)
                {
                    MessageBox.Show("User Successfully Updated");
                    dgvUserDetails.DataSource = uc.getUsers();
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
        int UserID = 0;
        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = uc.manageUsers(UserID, txtUsername.Text, txtPassword.Text, 1);
                if (rs==true)
                {
                    MessageBox.Show("User successfully created");
                    dgvUserDetails.DataSource=uc.getUsers();
                    helperClass.makeFieldsBlank(groupBox1);
                }
                else
                {
                    MessageBox.Show("Error in performing the required operation");
                    helperClass.makeFieldsBlank(groupBox1);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUserDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserID = int.Parse(dgvUserDetails.SelectedRows[0].Cells["UserID"].Value.ToString());
            txtUsername.Text = dgvUserDetails.SelectedRows[0].Cells["UserName"].Value.ToString();
            txtPassword.Text = dgvUserDetails.SelectedRows[0].Cells["Password"].Value.ToString();
            txtConfirmPassword.Text=txtPassword.Text;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = uc.manageUsers(UserID, txtUsername.Text, txtPassword.Text, 3);
                if (rs == true)
                {
                    MessageBox.Show("User Successfully Deleted");
                    dgvUserDetails.DataSource = uc.getUsers();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
