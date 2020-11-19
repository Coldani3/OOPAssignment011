namespace OOPAssignment011
{
    public class PetCapabilities
    {
        public bool CanGoUnderwater { get; private set; }
        public bool CanGoPlayBall { get; private set; }
        public bool CanFly { get; private set; }

        public PetCapabilities(bool canGoUnderwater, bool canPlayBall, bool canFly)
        {
            this.CanGoUnderwater = canGoUnderwater;
            this.CanGoPlayBall = canPlayBall;
            this.CanFly = canFly;
        }
    }
}