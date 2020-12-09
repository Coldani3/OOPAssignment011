namespace OOPAssignment011
{
    public class Heater : Other
    {
        public Heater() : base(100*Program.TickRate, "Heater", "Warms the room by 5 degrees.", 1)
        {

        }

        public override bool Use(Pet pet)
        {
            base.Use(pet);
            pet.Room.ChangeTemperature(+5);
            return true;
        }
    }
}