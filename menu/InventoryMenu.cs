using System;

namespace OOPAssignment011
{
    public class InventoryMenu : ArrowNavigableMenu
    {
        private int VerticalOffset = 0;

        public InventoryMenu()
        {
            this.UpdateInventory();
        }

        public override void Display()
        {
            Program.DisplayActionDescription(this.AvailableActions[this.SelectedIndex].Description);
            Console.SetCursorPosition(0, 3);

            int itemsCanBeDisplayed = Console.WindowHeight - 2;
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