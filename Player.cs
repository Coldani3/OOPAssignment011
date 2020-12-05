namespace OOPAssignment011
{
    public class Player
    {
        public PetCollection Pets;
        public Inventory PlayerInventory;
        public string Name = "";

        public Player(string name)
        {
            this.Pets = new PetCollection();
            this.PlayerInventory = new Inventory();
            this.Name = name;
        }

        public void SaveData(string filePath)
        {

        }   
    }
}