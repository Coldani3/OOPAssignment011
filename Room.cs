using System;

namespace OOPAssignment011
{
    public class Room : IUpdating
    {
        public float CurrentTemperature; //degrees Celsius
        //Items that alter the room over multiple turns should probably alter this
        public float AmbientTemperature { get; private set; }
        private static readonly float MinRatePerSecond = 0.02f;
        public bool WaterEnvironment { get; protected set; } = false;
        public bool SkyEnvironment { get; protected set; } = false;
        public string Name { get; protected set; } = "Room";
        public string Description { get; protected set; }

        public Room(string name, string description, float ambientTemperature, float startingTemperature, bool waterEnvironment = false, bool skyEnvironment = false)
        {
            this.AmbientTemperature = ambientTemperature;
            this.CurrentTemperature = startingTemperature;
            this.Name = name;
            this.Description = description;
            this.WaterEnvironment = waterEnvironment;
            this.SkyEnvironment = skyEnvironment;
        }

        public void Update()
        {
            //As it approaches the ambient temperature the rate of temperature change should slow to a mininum of 0.005 every second
            float temperatureDiff = this.AmbientTemperature - this.CurrentTemperature;
            float change = MinRatePerSecond * temperatureDiff;

            if (change < MinRatePerSecond)
            {
                change = MinRatePerSecond;
            }

            //Finally, adjust temperature so that it scales by tick
            change /= Program.TickRate;
            if (CurrentTemperature > AmbientTemperature)
            {
                this.ChangeTemperature(-change);
            }
            else
            {
                this.ChangeTemperature(change);
            }
        }

        public void ChangeTemperature(float by)
        {
            if ((this.CurrentTemperature > this.AmbientTemperature && this.CurrentTemperature + by < this.AmbientTemperature) 
                || (this.CurrentTemperature < this.AmbientTemperature && this.CurrentTemperature + by > this.AmbientTemperature))
            {
                this.CurrentTemperature = this.AmbientTemperature;
            }
            else
            {
                CurrentTemperature += by;
            }
        }

        public void ChangeAmbientTemperature(float by)
        {
            this.AmbientTemperature += by;
        }
    }
}