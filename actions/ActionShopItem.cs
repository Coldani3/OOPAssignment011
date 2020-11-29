namespace OOPAssignment011
{
    public class ActionShopItem : Action
    {
        private InventoryItem item;
        public ActionShopItem(InventoryItem item) : base(item.Name, item.Description)
        {
            this.item = item;
        }
        public override bool Execute(Pet pet)
        {
            pet.Owner.PlayerInventory.Coins -= item.Cost;
            return false;
        }

        public override bool CanPerformAction(Pet pet)
        {
            return pet.Owner.PlayerInventory.Coins >= item.Cost;
        }
    }
}