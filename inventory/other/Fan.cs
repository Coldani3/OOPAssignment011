namespace OOPAssignment011
{
    public class Fan : Other
    {
        public Fan() : base(100*Program.TickRate, "Fan", "Cools the room by 5 degrees.", 1)
        {

        }

        public override bool Use(Pet pet)
        {
            base.Use(pet);
            pet.Room.ChangeTemperature(-5);
            return true;
        }
    }
}