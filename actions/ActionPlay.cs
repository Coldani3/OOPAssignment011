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
            if (pet.Mood + 30 > 100)
            {
                pet.Mood = 100;
            }
            else
            {
                pet.Mood += 30;
            }
            pet.Hunger += 10;
            return true;
        }

        public override bool CanPerformAction(Pet pet)
        {
            return pet.Mood < 100 && pet.Hunger < 80;
        }
    }
}