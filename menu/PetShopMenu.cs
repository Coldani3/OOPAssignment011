namespace OOPAssignment011
{
    public class PetShopMenu : ArrowNavigableMenu
    {
        public PetShopMenu()
        {
            this.AvailableActions.Add(new ActionBuyPet(new PetShopItem("Cat", "Buy a cat!", 400*Program.TickRate, 1)));
            this.AvailableActions.Add(new ActionBuyPet(new PetShopItem("Dog", "Buy a dog!", 400*Program.TickRate, 2)));
        }
    }
}