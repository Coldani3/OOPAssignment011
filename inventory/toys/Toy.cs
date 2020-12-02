using System;

namespace OOPAssignment011
{
    public class Toy : InventoryItem
    {
        public Toy(int cost, string name, string description, int maxUses) : base(cost, name, description)
        {
            this.MaxUses = maxUses;
        }

        public override string GetItemType()
        {
            return InventoryItem.ToyType;
        }
    }
}