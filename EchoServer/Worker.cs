using System.IO;
using System.Net;
using System.Net.Sockets;

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
                DoClient(socket);
            }
        }

        

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string str = sr.ReadLine();

                
                sw.WriteLine($"{str} contains {str.Split(" ").Length} words" );
                sw.Flush();
            }


        }
    }
}