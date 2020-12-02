using System;

namespace OOPAssignment011
{
    public abstract class ArrowNavigableMenu : Menu
    {
        protected int SelectedIndex = 0;

        public override void HandleInput(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
            {
                if ((key.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    this.SelectedIndex = this.AvailableActions.Count - 1;
                    this.OnArrowNavigate(key);
                }
                else if (this.SelectedIndex < this.AvailableActions.Count - 1)
                {
                    this.SelectedIndex++;
                    this.OnArrowNavigate(key);
                }
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                if ((key.Modifiers & ConsoleModifiers.Control) != 0)
                {
                    this.SelectedIndex = 0;
                    this.OnArrowNavigate(key);
                }
                else if (this.SelectedIndex > 0)
                {
                    this.SelectedIndex--;
                    this.OnArrowNavigate(key);
                }
            }

            if (key.Key == ConsoleKey.Enter)
            {
                this.Select(this.SelectedIndex);
            }
        }

        public abstract void Select(int selectedIndex);

        public virtual void OnArrowNavigate(ConsoleKeyInfo key)
        {

        }
    }
}