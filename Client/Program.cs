using System;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker client = new Worker();
            client.start();
            Console.ReadLine();
        }
    }
}
