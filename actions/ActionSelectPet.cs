namespace OOPAssignment011
{
    public class ActionSelectPet : Action
    {
        private Pet newPet;
        public ActionSelectPet(Pet pet) : base(pet.Name, "")
        {
            this.newPet = pet;
        }

        public override bool Execute(Pet pet)
        {
            
            return base.Execute(pet);
        }
    }
}