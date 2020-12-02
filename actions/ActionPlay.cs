using System;

namespace OOPAssignment011
{
    public class ActionPlay : Action
    {
        public ActionPlay() : base("Play", "Play with your pet!")
        {

        }

        public override bool Execute(Pet pet)
        {
            //TODO: varying play bonuses based on a selected activity
            pet.Mood += 15;
            pet.Hunger += 10;
            return true;
        }

        public override bool CanPerformAction(Pet pet)
        {
            return pet.Mood < 100 && pet.Hunger < 80;
        }
    }
}