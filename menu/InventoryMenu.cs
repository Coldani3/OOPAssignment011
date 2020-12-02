using System;

namespace OOPAssignment011
{
    public class InventoryMenu : ArrowNavigableMenu
    {
        private int VerticalOffset = 0;
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
                Program.DisplayActionDescription(this.AvailableActions[this.SelectedIndex].Description);
                Console.SetCursorPosition(0, 3);

                itemsCanBeDisplayed = (Console.WindowHeight - 4) < this.AvailableActions.Count ? Console.WindowHeight - 4 : this.AvailableActions.Count;

                for (int i = this.VerticalOffset; i < this.itemsCanBeDisplayed; i++)
                {
                    if (i == this.SelectedIndex)
                    {
                        Program.StartSelectWrite();
                    }

                    Console.WriteLine($"{this.AvailableActions[i]}");

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
                this.AvailableActions[selectedIndex].Execute(this.ActivePet);
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
                if (this.VerticalOffset > 0 && this.SelectedIndex == this.VerticalOffset)
                {
                    this.VerticalOffset--;
                }
            }
            else
            {
                if (this.SelectedIndex - this.VerticalOffset == this.itemsCanBeDisplayed)
                {
                    this.VerticalOffset++;
                }
            }
        }
    }
}