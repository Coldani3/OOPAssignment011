using System;
using System.Threading;
using System.Threading.Tasks;

namespace OOPAssignment011
{
    public class Program
    {
        public static readonly ConsoleColor DefaultBGCol = ConsoleColor.Black;
        public static readonly ConsoleColor DefaultFGCol = ConsoleColor.White;
        public static readonly string BlankLine = new String(' ', Console.WindowWidth);
        public static readonly short TickRate = 10;
        public static bool Running = true;
        public static Player Player = new Player("John Smith");
        public static Menu Menu;
        //Save so that we can switch back to this easily
        public static MainMenu MainMenu;
        public static Menu PreviousMenu;

        public static char HorizontalLine = '─';
        public static char VerticalLine = '│';
        
        public static char BottomRightCorner = '┘';
        
        public static char BottomLeftCorner = '└';
        public static char TopLeftCorner = '┌';
        public static char TopRightCorner = '┘';
        public static char HorizontalVertJoiner = '┬';
        private static string finalMessage = "Bye!";
        private static readonly string TopHorizontalLine = new string(Program.HorizontalLine, Console.WindowWidth);

        public static Random random = new Random();
        public static long TicksPassed = 0;

        public static Room[] Rooms = new Room[] {
            new Room("Normal Room", "A room of average temperature.", 25, 18),
            new Room("Desert Room", "A really hot room.", 78, 68),
            new Room("Freezer Room", "A very cold room.", -4, 2),
            new Room("Sky Room", "A room on a floating island.", 11, 14, false, true)
        };

        static void Main(string[] args)
        {
            ShopItemRegistry.RegisterAll();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = false;
            Task mainLoopTask = new Task(Tick);
            
            Pet testPet = new Pet("John Doe", 100, 0, 0.5f, 100, new PetCapabilities(true, true, true, false, true), 25);
            Pet testPet2 = new Pet("Bob, Destroyer of Worlds", 100000, 0, 2.0f, 100, new PetCapabilities(false, false, false, true, true), 25);
            testPet.Room = Rooms[0];
            testPet2.Room = Rooms[0];
            Player.Pets.AddPet(testPet);
            Player.Pets.AddPet(testPet2);
            Player.Pets.SelectedPet = testPet;
            Player.Pets.SelectedPet.Room = Rooms[0];
            MainMenu = new MainMenu();
            Menu = MainMenu;
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
            //MainMenu = Menu;

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
                        Program.DisplayActionDescription(Menu.AvailableActions[Menu.SelectedIndex].Description);
                        Menu.Display();
                        DisplayPetStats(MainMenu);
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
                    TicksPassed++;
                    
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

        public static void DisplayPetStats(MainMenu menu)
        {
            //17 wide (largest is 15 wide)
            Console.SetCursorPosition(Console.WindowWidth - 16, 2);
            Console.Write(menu.ActivePet.Name);
            Console.SetCursorPosition(Console.WindowWidth - 16, 3);
            ChangeColorOnPositiveStat((menu.ActivePet.Health / menu.ActivePet.MaxHealth) * 100);
            int hpRounded = (int) Math.Floor(menu.ActivePet.Health);
            Console.Write($"Health: {hpRounded}/{menu.ActivePet.MaxHealth}");
            Console.SetCursorPosition(Console.WindowWidth - 16, 4);

            int hungerRounded = (int) Math.Floor(menu.ActivePet.Hunger);
            Program.ChangeColorOnNegativeStat(hungerRounded);
            Console.Write($"Hunger: {hungerRounded}/100");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Console.WindowWidth - 16, 5);

            int moodRounded = (int) Math.Floor(menu.ActivePet.Mood);
            Program.ChangeColorOnPositiveStat(moodRounded);

            Console.Write($"Mood: {moodRounded}/100");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Console.WindowWidth - 16, 6);
            Console.Write(menu.ActivePet.IsSick ? "Status: Sick": "Status: Healthy");

            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 17, 2 + i);
                Console.Write(Program.VerticalLine);
            }
            Console.SetCursorPosition(Console.WindowWidth - 17, 1);
            Console.Write(Program.HorizontalVertJoiner);

            Console.SetCursorPosition(Console.WindowWidth - 17, 7);
            Console.Write(Program.BottomLeftCorner);
            
            Console.SetCursorPosition(Console.WindowWidth - 16, 7);
            Console.Write(new String(Program.HorizontalLine, 16));
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
            Console.BackgroundColor = DefaultBGCol;
            Console.ForegroundColor = DefaultFGCol;
        }

        //Display bar at top with Action description
        public static void DisplayActionDescription(string description)
        {
            // Console.BackgroundColor = ConsoleColor.Gray;
            // Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 0);
            Console.Write(BlankLine);
            Console.SetCursorPosition(0, 0);
            Console.Write(description);
            Program.ResetConsoleColours();
            Console.SetCursorPosition(0, 1);
            Console.Write(TopHorizontalLine);
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
                MainMenu.ActivePet = newPet;
            }
            else
            {
                MessageUser("Menu is null on ChangePet!", 1500);
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

        public static void MessageUser(string message, int delay)
        {
            Console.WriteLine(message);
            Thread.Sleep(delay);
        }
    }
}
