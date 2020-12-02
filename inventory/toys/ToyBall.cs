namespace OOPAssignment011
{
    public class ToyBall : Toy
    {
        public ToyBall() : base(200, "Ball", "A bouncy ball your pet can play with! Lasts a good while.", 10)
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