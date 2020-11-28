using System;

namespace OOPAssignment011
{
    public class ActionPlay : Action
    {
        public ActionPlay(string name, string description) : base(name, description)
        {

        }

        public override bool Execute(Pet pet)
        {
            //TODO: varying play bonuses based on a selected activity
            pet.Mood += 30;
            return base.Execute(pet);
        }

        public override bool CanPerformAction(Pet pet)
        {
            return pet.Mood < 100 && pet.Hunger < 80;
        }
    }
}