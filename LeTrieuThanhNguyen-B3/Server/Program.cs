using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int recv;
            byte[] data = new byte[4];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ipep);

            Console.WriteLine("Waiting for a client...");

            IPEndPoint ipClient = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(ipClient);

            recv = newsock.ReceiveFrom(data, ref Remote);
            int clientChoosen = BitConverter.ToInt32(data, 0);

            Random rand = new Random();
            int serverChoosen = rand.Next(0, 2);

            if (clientChoosen == serverChoosen)
            {
                byte[] result = Encoding.ASCII.GetBytes("Hoa");
                newsock.SendTo(result, Remote);
            }

        }
    }
}
