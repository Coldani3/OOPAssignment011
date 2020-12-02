using System;

namespace OOPAssignment011
{
    public class InventoryMenu : ArrowNavigableMenu
    {
        private int VerticalOffset = 0;
        private Action mainMenuAction = new ActionGoToMainMenu();

        public InventoryMenu()
        {
            this.UpdateInventory();
            this.AvailableActions.Add(new ActionGoToMainMenu());
        }

        public override void Display()
        {
            this.UpdateInventory();
            this.AvailableActions.Add(mainMenuAction);

            if (this.AvailableActions.Count > 0)
            {
                Program.DisplayActionDescription(this.AvailableActions[this.SelectedIndex].Description);
                Console.SetCursorPosition(0, 3);

                int itemsCanBeDisplayed = (Console.WindowHeight - 4) < this.AvailableActions.Count ? Console.WindowHeight - 4 : this.AvailableActions.Count;

                for (int i = this.VerticalOffset; i < itemsCanBeDisplayed; i++)
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
        }

        public override void OnArrowNavigate(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {

            }
            else
            {

            }
        }
    }
}