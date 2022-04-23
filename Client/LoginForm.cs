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
        SqlConnection cnn;
        public LoginForm()
        {
            InitializeComponent();
            Connect();
        }

        void Connect()
        {
            try
            {
                cnn = new SqlConnection();
                cnn.ConnectionString = @"server=.; database=multi_chat;integrated security=true";
                cnn.Open();
                UpdateStatus("Database connection successful");
            }
            catch
            {
                MessageBox.Show("Can not connect to Database", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void CloseConnect()
        {
            cnn.Close();
            cnn = null;
        }


        void UpdateStatus(string s)
        {
            lblStatus.Text = s;
        }

        DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sql, cnn);
            DataTable data = new DataTable();

            adap.Fill(data);

            return data;
        }

        void CheckLogin()
        {
            string query = "SELECT clientName,clientPassword FROM client WHERE clientName = '" + txtUserName.Text + "' and clientPassword = '" + txtPassword.Text + "'";
            if (GetDataToTable(query).Rows.Count > 0)
            {
                ClientForm client = new ClientForm();
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
            CloseConnect();
            this.Close();
        }
    }
}
