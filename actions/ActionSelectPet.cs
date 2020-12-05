namespace OOPAssignment011
{
    public class ActionSelectPet : Action
    {
        private Pet newPet;
        private Menu menu;
        public ActionSelectPet(Pet pet, Menu menu) : base(pet.Name, "")
        {
            this.newPet = pet;
            this.menu = menu;
        }

        public override bool Execute(Pet pet)
        {
            Program.ChangePet(this.newPet);
            return true;
        }

        public override bool CanPerformAction(Pet pet)
        {
            return pet != newPet;
        }
    }
}