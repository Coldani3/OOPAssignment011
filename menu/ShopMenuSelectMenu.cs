namespace OOPAssignment011
{
    public class ShopMenuSelect : ArrowNavigableMenu
    {
        public ShopMenuSelect()
        {
            this.AvailableActions.Add(new ActionGoToMenu("Toys", "Shop for toys for your pet!", new ItemShopMenu(InventoryItem.ToyType)));
            this.AvailableActions.Add(new ActionGoToMenu("Food", "Shop for food for your pet!", new ItemShopMenu(InventoryItem.FoodType)));
            this.AvailableActions.Add(new ActionGoToMenu("Medicine", "Shop for medicine for your pet!", new ItemShopMenu(InventoryItem.MedicineType)));
            this.AvailableActions.Add(new ActionGoToMenu("Other", "Shop for stuff that doesn't fit in the other categories for your pet!", new ItemShopMenu(InventoryItem.OtherType)));
            this.AvailableActions.Add(new ActionGoToMainMenu());
        }
    }
}