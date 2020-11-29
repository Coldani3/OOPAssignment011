using System;

namespace OOPAssignment011
{
    public class Medicine : InventoryItem
    {
        public int HealthIncrease;
        public int HungerIncrease;

        private Func<Pet, bool> customUse;

        public Medicine(int healthIncrease, int hungerIncrease, int cost, string name, string description) : base(cost, name, description)
        {
            this.HealthIncrease = healthIncrease;
            this.HungerIncrease = hungerIncrease;
        }

        public override bool Use(Pet pet)
        {
            pet.Health += this.HealthIncrease;
            pet.Hunger += this.HungerIncrease;
            
            return true;
        }

        public override string GetItemType()
        {
            return InventoryItem.MedicineType;
        }
    }
}