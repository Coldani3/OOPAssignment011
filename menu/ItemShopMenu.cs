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
            this.AvailableActions.Add(new ActionGoToMainMenu());
        }

        public override void Display()
        {
            if (this.items.Count < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }

            Console.SetCursorPosition(0, 7);
            Console.Write(items.Count);
            this.items.ForEach(x => Console.Write(x.Name));

            base.Display();
            // Program.DisplayActionDescription(this.AvailableActions[this.SelectedIndex].Description);
            // Console.SetCursorPosition(0, 2);
            // for (int i = 0; i < this.AvailableActions.Count; i++)
            // {
            //     if (i == this.SelectedIndex)
            //     {
            //         Program.StartSelectWrite();
            //     }

            //     Console.WriteLine($"{i + 1}. {this.AvailableActions[i].ToString()}");

            //     Program.ResetConsoleColours();
            // }

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