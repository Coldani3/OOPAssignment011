namespace OOPAssignment011
{
    public class Food : InventoryItem
    {
        public int HealthRestored { get; private set; }

        public Food(int healthRestored, float cost, string name, string description) : base(cost, name, description)
        {
            this.HealthRestored = healthRestored;
        }

        public override string GetItemType()
        {
            return InventoryItem.FoodType;
        }

        public override bool Use(Pet pet)
        {
            pet.Health += this.HealthRestored;
            return true;
        }
    }
}