namespace OOPAssignment011
{
    public class ToyLaserPointer : Toy
    {
        public ToyLaserPointer() : base(50 * Program.TickRate, "Ball", "A bouncy ball your pet can play with! Can survive 10 uses.", 1)
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