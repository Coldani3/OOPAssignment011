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
        public static Menu Menu;
        //Save so that we can switch back to this easily
        public static Menu MainMenu;
        public static Menu PreviousMenu;

        public static char HorizontalLine = '─';
        public static char VerticalLine = '│';
        
        public static char BottomRightCorner = '┘';
        
        public static char BottomLeftCorner = '└';
        public static char TopLeftCorner = '┌';
        public static char TopRightCorner = '┘';
        public static char HorizontalVertJoiner = '┬';
        private static string finalMessage = "Bye!";

        public static Random random = new Random();

        static void Main(string[] args)
        {
            ShopItemRegistry.RegisterAll();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = false;
            Task mainLoopTask = new Task(Tick);
            Room startRoom = new Room(25, 18);
            Pet testPet = new Pet("John Doe", 100, 0, 0.5f, 100, new PetCapabilities(true, true, true, false, true));
            Pet testPet2 = new Pet("Bob, Destroyer of Worlds", 100000, 0, 2.0f, 100, new PetCapabilities(false, false, false, true, true));
            testPet.Room = startRoom;
            testPet2.Room = startRoom;
            Player.Pets.AddPet(testPet);
            Player.Pets.AddPet(testPet2);
            Player.Pets.SelectedPet = testPet;
            Player.Pets.SelectedPet.Room = startRoom;
            Menu = new MainMenu();
            Menu.ActivePet = Player.Pets.SelectedPet;
            Menu.CurrentPlayer = Player;
            // Player.PlayerInventory.AddItem(new ToyBall());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new ToyBall());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new FoodSteak());
            Player.PlayerInventory.AddItem(new ToyBall());
            Player.PlayerInventory.Coins = 1000;
            MainMenu = Menu;

            mainLoopTask.Start();

            //Input loop here
            try
            {
                while (Running)
                {
                    Menu.HandleInput(Console.ReadKey(true));
                }
            }
            catch (Exception e)
            {
                finalMessage = e.Message + e.StackTrace;
                Running = false;
            }

            Console.Clear();
            Console.WriteLine(finalMessage);

            Console.ReadKey();
        }

        public static void Tick()
        {
            try
            {
                while (Running)
                {
                    Console.Clear();

                    if (Menu != null)
                    {
                        Menu.Display();
                    }
                    else
                    {
                        Console.WriteLine("Null Menu! Falling back to Main Menu instead!");
                        Thread.Sleep(1000);
                        GotoMainMenu();
                    }
                    
                    //Do stuff here
                    Menu.ActivePet.Update();
                    Menu.ActivePet.Room.Update();
                    Player.PlayerInventory.Coins++;
                    
                    Thread.Sleep(1000 / TickRate);
                }
            }
            catch (Exception e)
            {
                Running = false;
                finalMessage = e.Message + e.StackTrace;
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
            Console.ForegroundColor = ConsoleColor.White;

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
            Console.ForegroundColor = ConsoleColor.White;

            if (stat <= 80)
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
            // Console.BackgroundColor = ConsoleColor.Gray;
            // Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 0);
            Console.Write(description);
            Program.ResetConsoleColours();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(new String(Program.HorizontalLine, Console.WindowWidth));
            Console.ResetColor();
        }

        public static void ChangePlayer(Player newPlayer)
        {
            Player.SaveData("players.txt");
            Player = newPlayer;
            Menu.CurrentPlayer = Player;
            MainMenu.CurrentPlayer = Player;
        }

        public static void ChangePet(Pet newPet)
        {
            if (Menu != null)
            {
                Player.Pets.SelectedPet = newPet;
                Menu.ActivePet = newPet;
            }
            else
            {
                DebugMessage("Menu is null on ChangePet!", 1500);
            }
            Program.MainMenu.ActivePet = newPet;
            //pet.Owner.Pets.SelectedPet = newPet;
        }

        public static void ChangeMenu(Menu newMenu)
        {
            PreviousMenu = Menu;
            Menu = newMenu;
        }

        public static void GoToPreviousMenu()
        {
            ChangeMenu(PreviousMenu);
        }

        public static void DebugMessage(string message, int delay)
        {
            Console.WriteLine(message);
            Thread.Sleep(delay);
        }
    }
}
