using System;
using System.Threading;
using System.Threading.Tasks;

namespace OOPAssignment011
{
    public class Program
    {
        public static readonly short TickRate = 20;
        public static bool Running = true;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Task mainLoopTask = new Task(Tick);
            mainLoopTask.Start();

            //Input loop here

            while (Running)
            {
                HandleInput(Console.ReadKey(true));
            }
        }

        public static void Tick()
        {
            //Do stuff here

            Thread.Sleep(1000 / TickRate);
        }

        public static void HandleInput(ConsoleKeyInfo key)
        {

        }
    }
}
