using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPAssignment011
{
    public class ShopItemRegistry
    {
        public static List<InventoryItem> ShopItems = new List<InventoryItem>();

        public static void AddItem(InventoryItem item)
        {
            ShopItems.Add(item);
        }

        public static List<InventoryItem> GetShopItemsByType(string type)
        {
            // List<InventoryItem> result = new List<InventoryItem>();

            // foreach (InventoryItem item in ShopItems)
            // {
            //     if (item.GetItemType() == type)
            //     {
            //         result.Add(item);
            //     }
            // }

            return /*result;*/(List<InventoryItem>) ShopItems.Where(x => type == x.GetItemType()).ToList();
        }

        public static void RegisterAll()
        {
            AddItem(new ToyBall());
            AddItem(new FoodSteak());
            AddItem(new Fan());
        }
    }
}