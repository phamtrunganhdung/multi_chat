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

namespace Server
{
    public partial class ServerForm : Form
    {
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;
        int clientOnline =0;
        ConnectDB cnnDB = new ConnectDB();
        public ServerForm()
        {
            InitializeComponent();
            ConnectToClient();
            CheckForIllegalCrossThreadCalls = false;
            cnnDB.Connect();
            GetNumberOfAllClient();
        }

        void ConnectToClient()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9090);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();

                        clientList.Add(client);
                        clientOnline = clientOnline + 1;
                        tsslClientOnline.Text = clientOnline.ToString();
                        Thread receive = new Thread(ReceiveData);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9090);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }
        void CloseServer()
        {
            server.Close();
        }
        void SendDataToAllClient(Socket client)
        {
            if (txtMessage.Text != string.Empty)
            {
                client.Send(SerializeData("server:   " +txtMessage.Text));
            }
            else
            {
                MessageBox.Show("Message can not be null", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void ReceiveData(object obj)
        {
            Socket client = obj as Socket;
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
                clientList.Remove(client);
                client.Close();
                clientOnline = clientOnline - 1;
                tsslClientOnline.Text = clientOnline.ToString();
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

        void GetNumberOfAllClient()
        {
            string query = "SELECT * FROM client";
            int numClient = 0;
            numClient = ConnectDB.GetDataToTable(query).Rows.Count;
            tsslAllClient.Text = numClient.ToString();
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseServer();
            cnnDB.CloseConnect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                SendDataToAllClient(item);
            }
            AddMessageToListView("server:   " +txtMessage.Text);
        }
    }
}
