namespace OOPAssignment011
{
    public class Other : InventoryItem
    {
        public Other(int cost, string name, string description, int maxUses) : base(cost, name, description)
        {
            this.MaxUses = maxUses;
        }

        public override ItemType GetItemType()
        {
            return ItemType.Other;
        }
    }
}