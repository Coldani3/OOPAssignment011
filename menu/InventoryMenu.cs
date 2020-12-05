using System;

namespace OOPAssignment011
{
    public class InventoryMenu : ScrollingArrowNavigableMenu
    {
        private Action mainMenuAction = new ActionGoToMainMenu();

        public InventoryMenu()
        {
            this.UpdateInventory();
        }

        public override void Display()
        {
            this.UpdateInventory();

            base.Display();
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
    }
}