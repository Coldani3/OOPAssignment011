using System;

namespace OOPAssignment011
{
    public abstract class ArrowNavigableMenu : Menu
    {
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

        public override void Display()
        {
            Program.DisplayActionDescription(this.AvailableActions[this.SelectedIndex].Description);
            Console.SetCursorPosition(0, 2);
            for (int i = 0; i < this.AvailableActions.Count; i++)
            {
                if (i == this.SelectedIndex)
                {
                    Program.StartSelectWrite();
                }

                Console.WriteLine($"{this.AvailableActions[i].ToString()}");

                Program.ResetConsoleColours();
            }
        }

        public virtual void Select(int selectedIndex)
        {
            if (selectedIndex < this.AvailableActions.Count)
            {
                if (this.AvailableActions[selectedIndex].CanPerformAction(this.ActivePet))
                {
                    this.AvailableActions[selectedIndex].Execute(this.ActivePet);
                }
            }
        }

        public virtual void OnArrowNavigate(ConsoleKeyInfo key)
        {

        }
    }
}