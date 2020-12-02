using System;

namespace OOPAssignment011
{
    public class Toy : InventoryItem
    {
        public int MaxUses { get; private set; }
        public int Uses;

        public Toy(int cost, string name, string description, int maxUses) : base(cost, name, description)
        {
            this.MaxUses = maxUses;
            this.Uses = maxUses;
        }

        public override bool Use(Pet pet)
        {
            this.Uses += 1;
            return true;
        }

        public override string GetItemType()
        {
            return InventoryItem.ToyType;
        }
    }
}