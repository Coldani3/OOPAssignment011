namespace OOPAssignment011
{
    public class ToyBall : Toy
    {
        public ToyBall() : base(150 * Program.TickRate, "Ball", "A bouncy ball your pet can play with! Can survive 10 uses.", 10)
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