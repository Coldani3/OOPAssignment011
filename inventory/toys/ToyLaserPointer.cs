namespace OOPAssignment011
{
    public class ToyLaserPointer : Toy
    {
        public ToyLaserPointer() : base(50 * Program.TickRate, "Laser Pointer", "A laser pointer your pet can play with!", 1)
        {

        }

        public override bool Use(Pet pet)
        {
            base.Use(pet);
            pet.Mood += 45;
            pet.Hunger += 15;
            return true;
        }
    }
}