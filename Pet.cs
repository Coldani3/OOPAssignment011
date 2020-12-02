using System;

namespace OOPAssignment011
{
    public class Pet : IUpdating
    {
        private static int lastID = 0;
        private int id;

        public string Name;
        public bool IsSick = false;
        //Maxes out at 100, or peak happiness
        public float Mood;
        private int health;
        public int Health { 
            get => health; 
            set 
            { 
                if (this.Health + value <= this.MaxHealth) 
                {
                    this.health = this.Health = value;
                }
                else
                {
                    this.health = this.MaxHealth;
                }
            }
        }
        public int MaxHealth { get; private set; }
        //Maxes out at 100, if it reaches 100 (most hunger) it takes damage. Rounded down whenever displayed.
        public float Hunger;
        //Amount of hunger to increase per second
        public float HungerRate;
        public PetCapabilities Capabilities;

        public Room Room;
        public Player Owner;

        public Pet(string name, int maxHealth, float hunger, float hungerRate, float mood, PetCapabilities petCapabilities)
        {
            this.MaxHealth = maxHealth;
            this.health = maxHealth;
            this.Name = name;
            this.Hunger = hunger;
            this.HungerRate = hungerRate;
            this.Mood = mood;
            this.Capabilities = petCapabilities;
        }

        public void Update()
        {
            this.Hunger += (HungerRate / Program.TickRate);
            this.Mood -= (float) (1.0f / Program.TickRate);
        }
    }
}