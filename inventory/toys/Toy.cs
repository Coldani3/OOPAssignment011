using System;

namespace OOPAssignment011
{
    public class Toy : InventoryItem
    {
        public Toy(int cost, string name, string description, int maxUses=Int32.MaxValue) : base(cost, name, description)
        {
            this.MaxUses = maxUses;
        }

        public override ItemType GetItemType()
        {
            return ItemType.Toy;
        }
    }
}