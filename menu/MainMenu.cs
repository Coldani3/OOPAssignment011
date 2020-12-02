using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPAssignment011
{
    public class MainMenu : ArrowNavigableMenu
    {
        public MainMenu()
        {
            this.AvailableActions.Add(new ActionPlay());
            ShopMenu shopMenu = new ShopMenu();
            InventoryMenu inventoryMenu = new InventoryMenu();
            this.AvailableActions.Add(new ActionGoToMenu("Shop", "Purchase things in ye olde shoppe.", shopMenu));
            this.AvailableActions.Add(new ActionGoToMenu("Inventory", "View your inventory.", inventoryMenu));
            //Change pet
            //Change room
            this.AvailableActions.Add(new ActionQuit());
        }

        public override void Display()
        {
            Program.DisplayActionDescription(AvailableActions[this.SelectedIndex].Description);
            this.DisplayPetStats();
            this.DisplaySelectMenu();
            this.DisplayRoomStatus();
        }

        public override void Select(int selectedIndex)
        {
            if (selectedIndex < this.AvailableActions.Count)
            {
                if (this.AvailableActions[this.SelectedIndex].CanPerformAction(this.ActivePet))
                {
                    this.AvailableActions[this.SelectedIndex].Execute(this.ActivePet);
                }
            }
        }

        private void DisplaySelectMenu()
        {
            int width = this.AvailableActions.Max((x) => x.Name.Length) + 5;
            Console.SetCursorPosition(0, 3);
            foreach (Action action in this.AvailableActions)
            {
                int actionNum = this.AvailableActions.IndexOf(action) + 1;
                bool selected = this.SelectedIndex + 1 == actionNum;

                if (selected)
                {
                    Program.StartSelectWrite();
                }

                Console.WriteLine($"{actionNum}. {action.ToString()}");

                if (selected)
                {
                    Program.ResetConsoleColours();
                }
            }

            for (int i = 2; i < this.AvailableActions.Count + 5; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.Write(Program.VerticalLine);
            }

            Console.SetCursorPosition(width, 1);
            Console.Write(Program.HorizontalVertJoiner);

            Console.SetCursorPosition(width, this.AvailableActions.Count + 5);
            Console.Write(Program.BottomRightCorner);

            Console.SetCursorPosition(0, this.AvailableActions.Count + 5);

            Console.WriteLine(new String(Program.HorizontalLine, width));
        }
        
        

        private void DisplayPetStats()
        {
            //17 wide (largest is 15 wide)
            Console.SetCursorPosition(Console.WindowWidth - 16, 2);
            Console.Write(this.ActivePet.Name);
            Console.SetCursorPosition(Console.WindowWidth - 16, 3);
            Program.ChangeColorOnPositiveStat((this.ActivePet.Health / this.ActivePet.MaxHealth) * 100);
            Console.Write($"Health: {this.ActivePet.Health}/{this.ActivePet.MaxHealth}");
            Console.SetCursorPosition(Console.WindowWidth - 16, 4);

            int hungerRounded = (int) Math.Floor(this.ActivePet.Hunger);
            Program.ChangeColorOnNegativeStat(hungerRounded);
            Console.Write($"Hunger: {hungerRounded}/100");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Console.WindowWidth - 16, 5);

            int moodRounded = (int) Math.Floor(this.ActivePet.Mood);
            Program.ChangeColorOnPositiveStat(moodRounded);

            Console.Write($"Mood: {moodRounded}/100");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(Console.WindowWidth - 16, 6);
            Console.Write(this.ActivePet.IsSick ? "Status: Sick": "Status: Healthy");

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

        private void DisplayRoomStatus()
        {
            //Console.SetCursorPosition();
            Console.SetCursorPosition(Console.WindowWidth - 16, 10);
            //TODO: Make text change colours based on pet's preference
            int roundedRoomTemp = (int) Math.Floor(this.ActivePet.Room.CurrentTemperature);
            Console.Write($"°C: {roundedRoomTemp}");
        }
    }
}