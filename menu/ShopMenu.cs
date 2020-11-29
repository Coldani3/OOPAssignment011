using System;

namespace OOPAssignment011
{
    public class ShopMenu : ArrowNavigableMenu
    {
        public ShopMenu(Player player)
        {

        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Select(int selectedIndex)
        {
            if (this.AvailableActions[selectedIndex].CanPerformAction(this.ActivePet))
            {
                this.AvailableActions[selectedIndex].Execute(this.ActivePet);
            }
        }
    }
}