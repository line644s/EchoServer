using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace EchoServer
{
    class Worker
    {
        public Worker()
        {
            
        }
        public void Start()
        {
            TcpListener sever = new TcpListener(IPAddress.Loopback, 7);
            sever.Start();

            while (true)
            {
                TcpClient socket = sever.AcceptTcpClient();
                //DoClient(socket);
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }
        }

        

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string str = sr.ReadLine();

                Thread.Sleep(5000);
                sw.WriteLine($"{str} contains {str.Split(" ").Length} words" );
                sw.Flush();
            }


        }
    }
}