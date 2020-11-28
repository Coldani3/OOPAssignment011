using System;

namespace OOPAssignment011
{
    public class Room : IUpdating
    {
        public float CurrentTemperature; //degrees Celsius
        //Items that alter the room over multiple turns should probably alter this
        public float AmbientTemperature { get; private set; }
        private static readonly float MinRatePerSecond = 0.005f;

        public Room(float ambientTemperature, float startingTemperature)
        {
            this.AmbientTemperature = ambientTemperature;
            this.CurrentTemperature = startingTemperature;
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
    }
}