namespace OOPAssignment011
{
    public class FoodSalad : Food
    {
        public FoodSalad() : base(0, 60, 50*Program.TickRate, "Salad", "A bowl of sald to eat!")
        {

        }

        public override bool IsCompatibleWith(Pet pet)
        {
            return pet.Capabilities.CanEatPlants;
        }
    }
}