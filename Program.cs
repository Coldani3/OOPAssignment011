using System;
using System.Threading;
using System.Threading.Tasks;

namespace OOPAssignment011
{
    class Program
    {
        public static readonly short TickRate = 20;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Task mainLoopTask = new Task(Tick);
            mainLoopTask.Start();

            //Input loop here
        }

        public static void Tick()
        {
            //Do stuff here

            Thread.Sleep(1000 / TickRate);
        }
    }
}
