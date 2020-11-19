using System;

namespace OOPAssignment011
{
    public class Toy : InventoryItem
    {
        public int MaxUses { get; private set; }
        public int Uses;
        private Func<Pet, bool> use;

        public Toy(int cost, string name, string description, int maxUses, Func<Pet, bool> use) : base(cost, name, description)
        {
            this.MaxUses = maxUses;
            this.Uses = maxUses;
        }

        public override bool Use(Pet pet)
        {
            return this.use(pet);
        }

        public override string GetItemType()
        {
            return "Toy";
        }
    }
}