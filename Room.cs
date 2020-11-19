namespace OOPAssignment011
{
    public class Room : IUpdating
    {
        public float CurrentTemperature;
        public float AmbientTemperature { get; private set; }

        public Room(float ambientTemperature, float startingTemperature)
        {
            this.AmbientTemperature = ambientTemperature;
            this.CurrentTemperature = startingTemperature;
        }

        public void Update()
        {

        }

        public void ChangeTemperature(float by)
        {
            CurrentTemperature += by;
        }
    }
}