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
            return true;
        }
    }
}