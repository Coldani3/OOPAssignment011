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
            Program.Player.PlayerInventory.Coins -= item.Cost;
            Program.Player.PlayerInventory.AddItem(this.item);
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