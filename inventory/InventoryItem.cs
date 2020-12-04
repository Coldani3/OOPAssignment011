using System;

namespace OOPAssignment011
{
    public abstract class InventoryItem
    {
        public static readonly string FoodType = "FOOD";
        public static readonly string ToyType = "TOY";
        public static readonly string MedicineType = "MEDICINE";
        public static readonly string OtherType = "OTHER";
        public int Cost { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int MaxUses { get; protected set; } = Int32.MaxValue;
        public int Uses;

        public InventoryItem(int cost, string name, string description)
        {
            this.Cost = cost;
            this.Name = name;
            this.Description = description;
        }

        public virtual bool Use(Pet pet)
        {
            this.Uses++;
            return true;
        }

        //ID that defines if it is a Toy, Food or Medicine object.
        public abstract string GetItemType();

        public virtual bool IsCompatibleWith(Pet pet)
        {
            return true;
        }

        public override string ToString()
        {
            string result = $"{this.Name}";

            if (this.Uses > 0)
            {
                result += $" {this.MaxUses - this.Uses}/{this.MaxUses}";
            }

            return result;
        }
    }
}