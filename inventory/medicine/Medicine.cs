using System;

namespace OOPAssignment011
{
    public class Medicine : InventoryItem
    {
        public int HealthIncrease;
        public int HungerIncrease;

        public Medicine(int healthIncrease, int hungerIncrease, int cost, string name, string description) : base(cost, name, description)
        {
            this.HealthIncrease = healthIncrease;
            this.HungerIncrease = hungerIncrease;
            this.MaxUses = 1;
        }

        public override bool Use(Pet pet)
        {
            base.Use(pet);
            pet.Health += this.HealthIncrease;
            pet.Hunger += this.HungerIncrease;
            
            return true;
        }

        public override ItemType GetItemType()
        {
            return ItemType.Medicine;
        }
    }
}