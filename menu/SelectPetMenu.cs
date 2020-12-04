namespace OOPAssignment011
{
    public class SelectPetMenu : ArrowNavigableMenu
    {
        public SelectPetMenu(Player player)
        {
            foreach (Pet pet in player.Pets.Pets)
            {
                this.AvailableActions.Add(new ActionSelectPet(pet));
            }

            this.AvailableActions.Add(new ActionGoToMainMenu());
        }
    }
}