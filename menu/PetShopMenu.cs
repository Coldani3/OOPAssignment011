namespace OOPAssignment011
{
    public class PetShopMenu : ArrowNavigableMenu
    {
        public PetShopMenu()
        {
            this.AvailableActions.Add(new ActionBuyPet(new PetShopItem("Cat", "Buy a cat!", 400*Program.TickRate, 1)));
            this.AvailableActions.Add(new ActionBuyPet(new PetShopItem("Dog", "Buy a dog!", 400*Program.TickRate, 2)));
            this.AvailableActions.Add(new ActionBuyPet(new PetShopItem("Lizard", "Buy a lizard!", 400*Program.TickRate, 3)));
            this.AvailableActions.Add(new ActionBuyPet(new PetShopItem("Fish", "Buy a fish!", 400*Program.TickRate, 4)));
            this.AvailableActions.Add(new ActionBuyPet(new PetShopItem("Bird", "Buy a bird!", 400*Program.TickRate, 5)));
        }
    }
}