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
            ShopMenu shopMenu = new ShopMenu(Program.Player);
            this.AvailableActions.Add(new ActionGoToMenu("Shop", "Purchase things in ye olde shoppe.", shopMenu));
            this.AvailableActions.Add(new ActionQuit());
        }

        public override void Display()
        {
            this.DisplayPetStats();
            this.DisplaySelectMenu();
            this.DisplayActionDescription(AvailableActions[this.SelectedIndex].Description);
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
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($"{actionNum}. {action.Name}");

                if (selected)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            for (int i = 2; i < this.AvailableActions.Count + 6; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.Write('│');
            }

            Console.SetCursorPosition(0, this.AvailableActions.Count + 5);

            Console.WriteLine(new String('_', width));
        }
        
        //Display bar at top with Action description on MAIN
        private void DisplayActionDescription(string description)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(description);
            Console.SetCursorPosition(0, 1);

            Console.WriteLine(new String('_', Console.WindowWidth));
        }

        private void DisplayPetStats()
        {
            //Console.SetCursorPosition();
            //17 wide (largest is 15 wide)
            Console.SetCursorPosition(Console.WindowWidth - 16, 2);
            Console.Write(this.ActivePet.Name);
            Console.SetCursorPosition(Console.WindowWidth - 16, 3);
            Console.Write($"Health: {this.ActivePet.Health}/{this.ActivePet.MaxHealth}");
            Console.SetCursorPosition(Console.WindowWidth - 16, 4);
            int hungerRounded = (int) Math.Floor(this.ActivePet.Hunger);
            Console.Write($"Hunger: {hungerRounded}/100");
            Console.SetCursorPosition(Console.WindowWidth - 16, 5);
            int moodRounded = (int) Math.Floor(this.ActivePet.Mood);
            Console.Write($"Mood: {moodRounded}/100");
            Console.SetCursorPosition(Console.WindowWidth - 16, 6);
            Console.Write(this.ActivePet.IsSick ? "Status: Sick": "Status: Healthy");

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 17, 2 + i);
                Console.Write("│");
            }
            
            Console.SetCursorPosition(Console.WindowWidth - 16, 7);
            Console.Write(new String('_', 16));
        }
    }
}