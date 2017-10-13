using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace CLient
{
    public partial class Form1 : Form
    {
        Socket server;
        IPEndPoint ipep;
        EndPoint remote;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "Keo";
            int a = 0;
            byte[] send = BitConverter.GetBytes(a);
            server.SendTo(send, (EndPoint)ipep);

            byte[] rec = new byte[20];
            remote = (EndPoint)ipep;
            server.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bao";
            int a = 0;
            byte[] send = BitConverter.GetBytes(a);
            server.SendTo(send, (EndPoint)ipep);

            byte[] rec = new byte[20];
            remote = (EndPoint)ipep;
            server.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bua";
            int a = 0;
            byte[] send = BitConverter.GetBytes(a);
            server.SendTo(send, (EndPoint)ipep);

            byte[] rec = new byte[20];
            remote = (EndPoint)ipep;
            server.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }

    }
}
