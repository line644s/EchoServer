using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MathServer
{
    internal class Worker
    {
        public void start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 3001);
            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();

                Task.Run(() => {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }

        }

        private void DoClient(TcpClient tempSocket)
        {
            using (StreamReader sr = new StreamReader(tempSocket.GetStream()))
            using (StreamWriter sw = new StreamWriter(tempSocket.GetStream()))
            {
                string str = sr.ReadLine();

                string[] strs = str.Split(" ");

                sw.WriteLine(int.Parse(strs[1]) + int.Parse(strs[2]));
                sw.Flush();
            }

            tempSocket?.Close();
        }
    }
}