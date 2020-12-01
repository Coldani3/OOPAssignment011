using System;
using System.Threading;
using System.Threading.Tasks;

namespace OOPAssignment011
{
    public class Program
    {
        public static readonly short TickRate = 10;
        public static bool Running = true;
        public static Menu Menu = new MainMenu();
        public static Player Player = new Player("John Smith");
        
        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Task mainLoopTask = new Task(Tick);
            mainLoopTask.Start();
            Player.Pets.SelectedPet = new Pet("John Doe", 100, 0, 0, 100, new PetCapabilities(true, true, true));
            Menu.ActivePet = Player.Pets.SelectedPet;

            //Input loop here

            while (Running)
            {
                Menu.HandleInput(Console.ReadKey(true));
            }

            Console.ReadKey();
            Console.Clear();
        }

        public static void Tick()
        {
            while (Running)
            {
                Console.Clear();
                Menu.Display();
                
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
