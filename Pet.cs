namespace OOPAssignment011
{
    public class Pet : IUpdating
    {
        private static int lastID = 0;
        private int id;

        public string Name;
        public bool IsSick = false;
        //Maxes out at 100
        public int Mood;
        public int Health;
        public int MaxHealth { get; private set; }
        //Maxes out at 100, if it reaches 100 (most hunger) it takes damage
        public int Hunger;
        public int HungerRate;
        public PetCapabilities Capabilities;

        public Pet(string name, int maxHealth, int hunger, int hungerRate, int mood, PetCapabilities petCapabilities)
        {
            this.MaxHealth = maxHealth;
            this.Health = this.MaxHealth;
            this.Name = name;
            this.Hunger = hunger;
            this.HungerRate = hungerRate;
            this.Mood = mood;
            this.Capabilities = petCapabilities;
        }

        public void Update()
        {

        }
    }
}