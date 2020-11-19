using System.Collections.Generic;

namespace OOPAssignment011
{
    public class PetCollection
    {
        public List<Pet> Pets = new List<Pet>();

        public void AddPet(Pet pet)
        {
            this.Pets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            this.Pets.Remove(pet);
        }
    }
}