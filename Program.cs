using System;
using System.Threading;
using System.Threading.Tasks;

namespace OOPAssignment011
{
    public class Program
    {
        public static readonly short TickRate = 10;
        public static bool Running = true;
        public static Player Player = new Player("John Smith");
        public static Menu Menu = new MainMenu();
        //Save so that we can switch back to this easily
        public static Menu MainMenu;
        
        
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = false;
            Task mainLoopTask = new Task(Tick);
            mainLoopTask.Start();
            Room startRoom = new Room(25, 18);
            Player.Pets.SelectedPet = new Pet("John Doe", 100, 0, 0.5f, 100, new PetCapabilities(true, true, true));
            Player.Pets.SelectedPet.Room = startRoom;
            Menu.ActivePet = Player.Pets.SelectedPet;
            // Player.PlayerInventory.AddItem(new ToyBall());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new ToyBall());
            Player.PlayerInventory.Coins = 1000;
            MainMenu = Menu;

            //Input loop here

            while (Running)
            {
                Menu.HandleInput(Console.ReadKey(true));
            }

            Console.Clear();
            Console.WriteLine("Bye!");

            Console.ReadKey();
        }

        public static void Tick()
        {
            while (Running)
            {
                Console.Clear();
                Menu.Display();
                
                //Do stuff here
                Menu.ActivePet.Update();
                Menu.ActivePet.Room.Update();
                Player.PlayerInventory.Coins++;
                
                Thread.Sleep(1000 / TickRate);
            }
        }

        public static void HandleInput(ConsoleKeyInfo key)
        {
            Menu.HandleInput(key);
        }

        public static void GotoMainMenu()
        {
            Menu = MainMenu;
        }

        public static void ChangeColorOnNegativeStat(float stat)
        {
            if (stat >= 30)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (stat >= 70)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            if (stat >= 90)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }

        public static void ChangeColorOnPositiveStat(float stat)
        {
            if (stat <= 90)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if (stat <= 50)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            if (stat <= 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }

        public static void StartSelectWrite()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void ResetConsoleColours()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Display bar at top with Action description
        public static void DisplayActionDescription(string description)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(description);
            Console.SetCursorPosition(0, 1);

            Console.WriteLine(new String('_', Console.WindowWidth));
        }
    }
}
