namespace OOPAssignment011
{
    public class ShopMenuSelect : ArrowNavigableMenu
    {
        public ShopMenuSelect()
        {
            this.AvailableActions.Add(new ActionGoToMenu("Toys", "Shop for toys for your pet!", new ItemShopMenu(ItemType.Toy)));
            this.AvailableActions.Add(new ActionGoToMenu("Food", "Shop for food for your pet!", new ItemShopMenu(ItemType.Food)));
            this.AvailableActions.Add(new ActionGoToMenu("Medicine", "Shop for medicine for your pet!", new ItemShopMenu(ItemType.Medicine)));
            this.AvailableActions.Add(new ActionGoToMenu("Other", "Shop for stuff that doesn't fit in the other categories for your pet!", new ItemShopMenu(ItemType.Other)));
            this.AvailableActions.Add(new ActionGoToMainMenu());
        }
    }
}