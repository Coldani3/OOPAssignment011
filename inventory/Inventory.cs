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
            return (List<Toy>) this.InventoryItems.Where((x) => x.GetItemType() == InventoryItem.ToyType);
        }

        public List<Medicine> GetMedicine()
        {
            return (List<Medicine>) this.InventoryItems.Where((x) => x.GetItemType() == InventoryItem.MedicineType);
        }

        public List<Food> GetFood()
        {
            return (List<Food>) this.InventoryItems.Where((x) => x.GetItemType() == InventoryItem.FoodType);   
        }
        
    }
}