using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Server
{
    public class ConnectDB
    {
        public static SqlConnection cnn;
        public void Connect()
        {
            try
            {
                cnn = new SqlConnection();
                cnn.ConnectionString = @"server=.; database=multi_chat;integrated security=true";
                cnn.Open();
            }
            catch
            {
                MessageBox.Show("Can not connect to Database", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void CloseConnect()
        {
            cnn.Close();
            cnn = null;
        }


        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sql, cnn);
            DataTable data = new DataTable();

            adap.Fill(data);

            return data;
        }

    }
}
