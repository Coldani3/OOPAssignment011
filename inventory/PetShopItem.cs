namespace OOPAssignment011
{
    public class PetShopItem
    {
        public int Cost { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ID { get; private set; }
        public PetShopItem(string name, string description, int cost, int id)
        {
            this.Name = name;
            this.Description = description;
            this.Cost = cost;
            this.ID = id;
        }
    }
}