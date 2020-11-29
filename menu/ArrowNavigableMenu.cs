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
                if ((key.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    this.SelectedIndex = this.AvailableActions.Count - 1;
                }
                else if (this.SelectedIndex < this.AvailableActions.Count - 1)
                {
                    this.SelectedIndex++;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if ((key.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    this.SelectedIndex = 0;
                }
                else if (this.SelectedIndex > 0)
                {
                    this.SelectedIndex--;
                }
            }

            if (key.Key == ConsoleKey.Enter)
            {
                this.Select(this.SelectedIndex);
            }
        }

        public abstract void Select(int selectedIndex);
    }
}