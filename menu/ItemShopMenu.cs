using System;
using System.Collections.Generic;

namespace OOPAssignment011
{
    public class ItemShopMenu : ArrowNavigableMenu
    {
        private List<InventoryItem> items;
        public ItemShopMenu(ItemType shopItemsType)
        {
            items = ShopItemRegistry.GetShopItemsByType(shopItemsType);

            foreach (InventoryItem item in this.items)
            {
                this.AvailableActions.Add(new ActionShopItem(item));
            }

            // this.AvailableActions.Add(new ActionShopItem(new ToyBall()));
            // this.AvailableActions.Add(new ActionShopItem(new FoodSteak()));
            this.AvailableActions.Add(new ActionPreviousMenu());
            this.AvailableActions.Add(new ActionGoToMainMenu());
        }

        public override void Display()
        {
            base.Display();

            Console.SetCursorPosition(Console.WindowWidth - 14, 2);
            Console.Write($"Coins: {Program.Player.PlayerInventory.Coins}");
        }

        public override void Select(int selectedIndex)
        {
            if (this.AvailableActions[selectedIndex].CanPerformAction(this.ActivePet))
            {
                this.AvailableActions[selectedIndex].Execute(this.ActivePet);
            }
        }
    }
}