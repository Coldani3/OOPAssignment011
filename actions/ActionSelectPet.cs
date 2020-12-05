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
            menu.ActivePet = newPet;
            pet.Owner.Pets.SelectedPet = newPet;
            return true;
        }
    }
}