namespace OOPAssignment011 
{
    public class BoilerRoom : Other
    {
        public BoilerRoom() : base(250*Program.TickRate, "Boiler", "Permanently raises the room's ambient temperature by 5 degrees.", 1)
        {

        }

        public override bool Use(Pet pet)
        {
            base.Use(pet);
            pet.Room.ChangeAmbientTemperature(5);
            return true;
        }
    }
}