namespace OOPAssignment011
{
    public abstract class InventoryItem
    {
        public static readonly string FoodType = "FOOD";
        public static readonly string ToyType = "TOY";
        public static readonly string MedicineType = "MEDICINE";
        public float Cost { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public InventoryItem(float cost, string name, string description)
        {
            this.Cost = cost;
            this.Name = name;
            this.Description = description;
        }

        public abstract bool Use(Pet pet);

        //ID that defines if it is a Toy, Food or Medicine object.
        public abstract string GetItemType();
    }
}