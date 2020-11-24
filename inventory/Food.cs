namespace OOPAssignment011
{
    public class Food : InventoryItem
    {
        public Food(int healthRestored, float cost, string name, string description) : base(cost, name, description)
        {

        }

        public override string GetItemType()
        {
            return InventoryItem.FoodType;
        }

        public override bool Use(Pet pet)
        {
            
        }
    }
}