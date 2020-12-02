namespace OOPAssignment011
{
    public class ActionUseItem : Action
    {
        private InventoryItem item;
        public ActionUseItem(InventoryItem item) : base(item.Name, item.Description)
        {
            this.item = item;
        }

        public override bool Execute(Pet pet)
        {
            this.item.Use(pet);
            if (this.item.Uses >= this.item.MaxUses)
            {
                Program.Player.PlayerInventory.RemoveItem(this.item);
            }
            return true;
        }

        public override string ToString()
        {
            return item.ToString();
        }
    }
}