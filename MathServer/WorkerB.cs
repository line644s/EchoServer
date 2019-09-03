using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MathServer
{
    internal class WorkerB
    {
        public void start()
        {
            
            TcpListener server = new TcpListener(IPAddress.Loopback, 3002);
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

                string[] strs = str.Split();

                if (strs[0].ToUpper() == "ADD")
                {
                    sw.WriteLine(double.Parse(strs[1], new CultureInfo("da-DK")) + double.Parse(strs[2], new CultureInfo("da-DK")));
                }
                else if (strs[0].ToUpper() == "SUB")
                {
                    sw.WriteLine(double.Parse(strs[1], new CultureInfo("da-DK")) -
                                 double.Parse(strs[2], new CultureInfo("da-DK")));

                }
                else if (strs[0].ToUpper() == "MUL")
                {
                    sw.WriteLine(double.Parse(strs[1], new CultureInfo("da-DK")) *
                                 double.Parse(strs[2], new CultureInfo("da-DK")));
                }
                else if (strs[0].ToUpper() == "DIV")
                {
                    sw.WriteLine(double.Parse(strs[1], new CultureInfo("da-DK")) /
                                 double.Parse(strs[2], new CultureInfo("da-DK")));
                }
                else
                {
                    sw.WriteLine("error, write Add, sub, mul or div first");
                }

                sw.Flush();
            }
            
        }
    }
}