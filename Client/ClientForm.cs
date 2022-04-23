using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        IPEndPoint IP;
        Socket client;
        public string ClientName
        {
            get
            {
                return lblClient.Text;
            }
            set
            {
                lblClient.Text = value;
            }
        }
        public ClientForm()
        {
            InitializeComponent();
            ConnectToSerrver();
            CheckForIllegalCrossThreadCalls = false;
        }

        void ConnectToSerrver()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9090);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Can not connect to server", "Error",
      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            

            Thread listen = new Thread(ReceiveData);
            listen.IsBackground = true;
            listen.Start();
        }
        void CloseClient()
        {
            client.Close();
        }
        void SendData()
        {
            if(txtMessage.Text != string.Empty)
            {
                client.Send(SerializeData(ClientName + ":   " + txtMessage.Text));
            }
            else
            {
                MessageBox.Show("Message can not be null", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ReceiveData()
        {
            try
            { 
                while (true)
                {      
                byte[] data = new byte[1024 * 1000];
                client.Receive(data);

                string message = (string)DeserializeData(data);
                AddMessageToListView(message);
                }
            }
            catch
            {
                CloseClient();
            }
        }

        void AddMessageToListView(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
            txtMessage.Clear();
        }

        byte[] SerializeData(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }
        object DeserializeData(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendData();
            AddMessageToListView(ClientName + ":   " + txtMessage.Text);
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClient();
        }
    }
}
