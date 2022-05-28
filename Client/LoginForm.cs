using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        ConnectDB cnnDB = new ConnectDB();
        public LoginForm()
        {
            InitializeComponent();
            cnnDB.Connect();
        }

       
        void UpdateStatus(string s)
        {
            lblStatus.Text = s;
        }

        void CheckLogin()
        {
           
            string queryIP = "SELECT clientIP FROM client WHERE clientName = '" + txtUserName.Text + "' and clientPassword = '" + txtPassword.Text + "'";
            if (cnnDB.GetDataToTable(queryIP).Rows.Count > 0)
            {
                ClientForm client = new ClientForm();
              
                client.usersIP = cnnDB.GetDataToTable(queryIP);
                client.ClientName = txtUserName.Text;
                client.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The account or password is incorrect. Please check again.", "Login failed");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            cnnDB.CloseConnect();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUpForm signup = new SignUpForm();
            signup.ShowDialog();
        }
    }
}
