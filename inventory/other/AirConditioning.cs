namespace OOPAssignment011 
{
    public class AirConditioning : Other
    {
        public AirConditioning() : base(250*Program.TickRate, "Air Conditioning", "Permanently lowers the room's ambient temperature by 5 degrees.", 1)
        {

        }

        public override bool Use(Pet pet)
        {
            base.Use(pet);
            pet.Room.ChangeAmbientTemperature(-5);
            return true;
        }
    }
}