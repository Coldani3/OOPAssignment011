namespace OOPAssignment011
{
    public abstract class InventoryItem
    {
        public int Cost { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public InventoryItem(int cost, string name, string description)
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