namespace OOPAssignment011
{
    public class PetCapabilities
    {
        public bool CanGoUnderwater { get; private set; }
        public bool CanGoPlayBall { get; private set; }
        public bool CanFly { get; private set; }
        public bool CanEatMeat { get; private set; }
        public bool CanEatPlants { get; private set; }

        public PetCapabilities(bool canGoUnderwater, bool canPlayBall, bool canFly, bool canEatMeat, bool canEatPlants)
        {
            this.CanGoUnderwater = canGoUnderwater;
            this.CanGoPlayBall = canPlayBall;
            this.CanFly = canFly;
            this.CanEatMeat = canEatMeat;
            this.CanEatPlants = canEatPlants;
        }
    }
}