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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        Database.UserClass uc = new Database.UserClass();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool rs = uc.login(txtUsername.Text, txtPassword.Text);
                if (rs == true)
                {
                    MainForm frm = new MainForm();
                    frm.lblIUserName.Text = txtUsername.Text;
                    frm.Show();
                }
                else
                {

                    MessageBox.Show("Error in performing the required operation");
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
