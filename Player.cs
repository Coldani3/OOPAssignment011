namespace OOPAssignment011
{
    public class Player
    {
        public PetCollection Pets = new PetCollection();
        public Inventory PlayerInventory = new Inventory();
        public string Name = "";

        public Player(string name)
        {
            this.Name = name;
        }

        public void SaveData(string filePath)
        {

        }   
    }
}