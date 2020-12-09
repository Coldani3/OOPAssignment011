using System;

namespace OOPAssignment011
{
    public class Pet : IUpdating
    {
        private static int lastID = 0;
        private int id;

        public string Name;
        public bool IsSick = false;
        public int PreferredTemperature = 25;
        //Maxes out at 100, or peak happiness
        private float mood;
        public float Mood { 
            get => this.mood; 
            set 
            { 
                if (value > 100) 
                {
                    this.mood = 100;
                }
                else if (value <= 0)
                {
                    this.mood = 0;
                }
                else
                {
                    this.mood = value;
                }
            }
        }
        private float health;
        public float Health { 
            get => this.health; 
            set 
            { 
                if (value > this.MaxHealth) 
                {
                    this.health = this.MaxHealth;
                }
                else if (value < 0)
                {
                    this.mood = 0;
                }
                else
                {
                    this.health = value;
                }
            }
        }
        public float MaxHealth { get; private set; }
        //Maxes out at 100, if it reaches 100 (most hunger) it takes damage. Rounded down whenever displayed.
        private float hunger;
        public float Hunger
        {
            get => this.hunger; 
            set 
            { 
                if (value > 100)
                {
                    this.hunger = 100;
                }
                else if (value < 0)
                {
                    this.hunger = 0;
                }
                else
                {
                    this.hunger = value;
                }
            }
        }
        //Amount of hunger to increase per second
        public float HungerRate;
        public PetCapabilities Capabilities;

        public Room Room;
        public Player Owner;

        public Pet(string name, int maxHealth, float hunger, float hungerRate, float mood, PetCapabilities petCapabilities, int preferredTemperature)
        {
            this.MaxHealth = maxHealth;
            this.health = maxHealth;
            this.Name = name;
            this.Hunger = hunger;
            this.HungerRate = hungerRate;
            this.Mood = mood;
            this.Capabilities = petCapabilities;
            this.PreferredTemperature = preferredTemperature;
        }

        public void Update()
        {
            float temperatureDifference = (float) Math.Abs(this.PreferredTemperature - this.Room.CurrentTemperature);
            this.Hunger += (HungerRate / Program.TickRate);
            float MoodDecayRate = (this.Hunger >= 50 ? 2.0f : 1.5f) + (0.25f * (((temperatureDifference - 10) >= 0 ? (temperatureDifference - 10) : 0) / 8.0f));
            this.Mood -= (float) (MoodDecayRate / Program.TickRate);

            if (this.Room.WaterEnvironment && !this.Capabilities.CanGoUnderwater)
            {
                this.Health -= (float) (1.0f / Program.TickRate);
            }

            if (temperatureDifference > 30)
            {
                this.Health -= (temperatureDifference - 30) / 10;
            }

            if (this.Hunger >= 80)
            {
                this.Health -= (5.0f / Program.TickRate) * (1.0f / (61.0f - (this.Hunger - 40.0f)));
            }

            if (Math.Floor(this.Health) <= 0)
            {
                this.Owner.Pets.RemovePet(this);
                Console.Clear();
                Program.MessageUser($"Your pet {this.Name} died :[", 2000);
                Program.Menu = new SelectPetMenu(this.Owner);
            }
        }
    }
}