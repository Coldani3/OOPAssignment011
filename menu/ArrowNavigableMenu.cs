using System;

namespace OOPAssignment011
{
    public abstract class ArrowNavigableMenu : Menu
    {
        protected int SelectedIndex = 0;

        public override void HandleInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (this.SelectedIndex < this.AvailableActions.Count)
                {
                    this.SelectedIndex++;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (this.SelectedIndex > 0)
                {
                    this.SelectedIndex--;
                }
            }
        }
    }
}