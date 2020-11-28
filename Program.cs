using System;
using System.Threading;
using System.Threading.Tasks;

namespace OOPAssignment011
{
    public class Program
    {
        public static readonly short TickRate = 20;
        public static bool Running = true;
        public static Menu Menu = new MainMenu();
        public static Player Player = new Player("John Smith");
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Task mainLoopTask = new Task(Tick);
            mainLoopTask.Start();

            //Input loop here

            while (Running)
            {
                Menu.HandleInput(Console.ReadKey(true));
            }

            Console.ReadKey();
        }

        public static void Tick()
        {
            while (Running)
            {
                //Do stuff here
                Menu.ActivePet.Update();
                

                Thread.Sleep(1000 / TickRate);
            }
        }

        public static void HandleInput(ConsoleKeyInfo key)
        {
            Menu.HandleInput(key);
        }
    }
}
