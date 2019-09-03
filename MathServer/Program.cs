using System;
using System.ComponentModel;

namespace MathServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker serverA = new Worker();
            WorkerB serverB = new WorkerB();

            //serverA.start();
            serverB.start();
            Console.ReadLine();
        }
    }
}
