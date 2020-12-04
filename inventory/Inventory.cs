using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPAssignment011
{
    public class Inventory
    {
        public List<InventoryItem> InventoryItems = new List<InventoryItem>();
        public int Coins = 0;

        public void Display(int xCoord, int yCoord)
        {
            for (int i = 0; i < this.InventoryItems.Count; i++)
            {
                InventoryItem item = InventoryItems[i];
                Console.SetCursorPosition(xCoord, yCoord + i);
                Console.Write(item.GetItemType() + ": " + item.Name);
            }
        }

        public void AddItem(InventoryItem item)
        {
            this.InventoryItems.Add(item);
        }

        public void RemoveItem(InventoryItem item)
        {
            this.InventoryItems.Remove(item);
        }

        public void RemoveItem(int index)
        {
            this.InventoryItems.RemoveAt(index);
        }

        public List<Toy> GetToys()
        {
            return (List<Toy>) this.InventoryItems.Where((x) => x.GetItemType() == ItemType.Toy);
        }

        public List<Medicine> GetMedicine()
        {
            return (List<Medicine>) this.InventoryItems.Where((x) => x.GetItemType() == ItemType.Medicine);
        }

        public List<Food> GetFood()
        {
            return (List<Food>) this.InventoryItems.Where((x) => x.GetItemType() == ItemType.Food);   
        }
        
    }
}