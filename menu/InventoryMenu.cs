using System;

namespace OOPAssignment011
{
    public class InventoryMenu : ArrowNavigableMenu
    {
        private int Scroll = 0;
        private Action mainMenuAction = new ActionGoToMainMenu();

        private int itemsCanBeDisplayed;

        public InventoryMenu()
        {
            this.UpdateInventory();
        }

        public override void Display()
        {
            this.UpdateInventory();

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
                        Console.WriteLine($"{this.AvailableActions[i]}");// - {i}");
                    }

                    Program.ResetConsoleColours();
                }
            }
            else
            {
                Console.WriteLine("Your inventory is empty!");
            }
        }

        public override void Select(int selectedIndex)
        {
            if (this.AvailableActions[selectedIndex].CanPerformAction(this.ActivePet))
            {
                //Action prevAction = this.AvailableActions[selectedIndex];
                this.AvailableActions[selectedIndex].Execute(this.ActivePet);

                // if (!Object.ReferenceEquals(prevAction, this.AvailableActions[selectedIndex]))//prevAction != this.AvailableActions[selectedIndex])
                // {
                //     this.Scroll--;
                // }

                this.UpdateInventory();
            }
        }

        public void UpdateInventory()
        {
            this.AvailableActions.Clear();

            if (Program.Player.PlayerInventory.InventoryItems.Count > 0)
            {
                foreach (InventoryItem item in Program.Player.PlayerInventory.InventoryItems)
                {
                    this.AvailableActions.Add(new ActionUseItem(item));
                }
            }

            this.AvailableActions.Add(mainMenuAction);
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