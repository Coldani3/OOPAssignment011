using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPAssignment011
{
    public class MainMenu : ArrowNavigableMenu
    {
        public override void Display()
        {
            this.DisplayPetStats();
            this.DisplaySelectMenu();
            this.DisplayActionDescription(AvailableActions[this.SelectedIndex].Description);
        }

        private void DisplaySelectMenu()
        {
            int width = this.AvailableActions.Max((x) => x.Name.Length) + 2;
            Console.SetCursorPosition(0, 3);
            foreach (Action action in this.AvailableActions)
            {
                int actionNum = this.AvailableActions.IndexOf(action) + 1;

                if (this.SelectedIndex + 1 == actionNum)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($"{actionNum}. {action.Name}");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (int i = 0; i < this.AvailableActions.Count + 4; i++)
            {
                Console.SetCursorPosition(width, i);
                Console.Write("|");
            }

            Console.SetCursorPosition(0, this.AvailableActions.Count + 5);
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
        }
        
        //Display bar at top with Action description on MAIN
        private void DisplayActionDescription(string description)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(description);
            Console.SetCursorPosition(0, 1);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
        }

        private void DisplayPetStats()
        {

        }
    }
}