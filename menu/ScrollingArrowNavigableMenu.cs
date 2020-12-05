using System;

namespace OOPAssignment011
{
    public class ScrollingArrowNavigableMenu : ArrowNavigableMenu
    {
        protected int itemsCanBeDisplayed;
        public int Scroll = 0;

        public override void Display()
        {
            if (this.AvailableActions.Count > 0)
            {
                itemsCanBeDisplayed = (Console.WindowHeight - 4) < this.AvailableActions.Count ? Console.WindowHeight - 4 : this.AvailableActions.Count;

                Program.DisplayActionDescription(this.AvailableActions[this.SelectedIndex].Description);
                Console.SetCursorPosition(0, 3);

                for (int i = this.Scroll; i < this.itemsCanBeDisplayed + this.Scroll; i++)
                {
                    if (i == this.SelectedIndex)
                    {
                        Program.StartSelectWrite();
                    }

                    if (i < this.AvailableActions.Count)
                    {
                        Console.WriteLine($"{this.AvailableActions[i]}");
                    }

                    Program.ResetConsoleColours();
                }
            }
        }

        public override void OnArrowNavigate(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (this.Scroll > 0 && this.SelectedIndex == this.Scroll)
                {
                    this.Scroll--;
                }
            }
            else
            {
                if (this.SelectedIndex - this.Scroll == this.itemsCanBeDisplayed)
                {
                    this.Scroll++;
                }
            }
        }
    }
}