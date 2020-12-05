namespace OOPAssignment011
{
    public class SelectPetMenu : ScrollingArrowNavigableMenu
    {
        public SelectPetMenu(Player player)
        {
            if (player.Pets.Pets.Count > 0)
            {
                foreach (Pet pet in player.Pets.Pets)
                {
                    this.AvailableActions.Add(new ActionSelectPet(pet, this));
                }
            }

            this.AvailableActions.Add(new ActionGoToMainMenu());
        }
    }
}