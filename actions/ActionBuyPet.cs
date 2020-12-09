using System;

namespace OOPAssignment011
{
    public class ActionBuyPet : Action
    {
        private PetShopItem item;
        public ActionBuyPet(PetShopItem item) : base(item.Name, item.Description)
        {
            this.item = item;
        }

        public override bool Execute(Pet pet)
        {
            Pet newPet;
            switch (item.ID)
            {
                //cat
                case 1:
                    newPet = new Pet("Cat", 100, 0, 0.3f, 100, new PetCapabilities(false, true, false, true, false), 25);
                    break;

                //dog
                case 2:
                    newPet = new Pet("Dog", 110, 0, 0.5f, 100, new PetCapabilities(true, true, false, true, false), 25);
                    break;

                //lizard
                case 3:
                    newPet = new Pet("Lizard", 80, 0, 0.2f, 100, new PetCapabilities(true, false, false, true, true), 45);
                    break;

                //fish
                case 4:
                    newPet = new Pet("Fish", 60, 0, 0.1f, 100, new PetCapabilities(true, false, false, false, true), 10);
                    break;

                //Bird
                case 5:
                    newPet = new Pet("Bird", 90, 0, 0.2f, 100, new PetCapabilities(false, false, true, true, false), 25);
                    break;

                default:
                    goto case 1;
            }
            Program.Player.PlayerInventory.Coins -= item.Cost;
            Program.Player.Pets.AddPet(newPet);
            Program.ChangeMenu(new NamePetMenu(newPet));
            //Program.Player.PlayerInventory.AddItem((InventoryItem) Activator.CreateInstance(item.GetType()));
            return false;
        }

        public override bool CanPerformAction(Pet pet)
        {
            return Program.Player.PlayerInventory.Coins >= item.Cost;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.item.Cost} Coins";
        }
    }
}