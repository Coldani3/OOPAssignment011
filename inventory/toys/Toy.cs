using System;

namespace OOPAssignment011
{
    public class Toy : InventoryItem
    {
        public int MaxUses { get; private set; }
        public int Uses;

        public Toy(float cost, string name, string description, int maxUses, Func<Pet, bool> use) : base(cost, name, description)
        {
            this.MaxUses = maxUses;
            this.Uses = maxUses;
        }

        public override bool Use(Pet pet)
        {
            return true;
        }

        public override string GetItemType()
        {
            return InventoryItem.ToyType;
        }
    }
}