namespace OOPAssignment011
{
    public class Room : IUpdating
    {
        public float CurrentTemperature; //degrees Celsius
        //Items that alter the room over multiple turns should probably alter this
        public float AmbientTemperature { get; private set; }
        private static readonly float RatePerSecond = 0.02f;

        public Room(float ambientTemperature, float startingTemperature)
        {
            this.AmbientTemperature = ambientTemperature;
            this.CurrentTemperature = startingTemperature;
        }

        public void Update()
        {
            //Temperature should go change by 0.1 every five seconds by default - 0.02 every second
            //As it approaches the ambient temperature this rate should slow to a mininum of 0.005 every second
            float change = 0.0f;

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
            CurrentTemperature += by;
        }
    }
}