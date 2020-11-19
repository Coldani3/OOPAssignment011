namespace OOPAssignment011
{
    public class Pet : IUpdating
    {
        private static int lastID = 0;
        private int id;

        public string Name;
        public bool IsSick = false;
        public int Mood;
        public int Health;
        public int MaxHealth { get; private set; }
        public int Hunger;
        public int HungerRate;
        public PetCapabilities Capabilities;

        public Pet(string name, int maxHealth, int hunger, int hungerRate, int mood, PetCapabilities petCapabilities)
        {
            
        }

        public void Update()
        {

        }
    }
}