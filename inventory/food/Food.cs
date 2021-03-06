namespace OOPAssignment011
{
    public class Food : InventoryItem
    {
        public int HealthRestored { get; private set; }
        public int HungerRestored { get; private set; }

        //public float TimeToEat { get; private set; }

        public Food(int healthRestored, int hungerRestored, int cost, string name, string description) : base(cost, name, description)
        {
            this.HealthRestored = healthRestored;
            this.HungerRestored = hungerRestored;
            this.MaxUses = 1;
            //this.TimeToEat = timeToEat;
        }

        public override ItemType GetItemType()
        {
            return ItemType.Food;
        }

        public override bool Use(Pet pet)
        {
            base.Use(pet);
            pet.Health += this.HealthRestored;
            pet.Hunger -= this.HungerRestored;
            //pet.Eating += this.HungerRestored;
            return true;
        }
    }
}