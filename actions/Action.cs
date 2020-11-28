namespace OOPAssignment011
{
    public class Action
    {
        public string Name;
        public string Description;

        public Action(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public virtual bool Execute(Pet pet)
        {
            return true;
        }

        public virtual bool CanPerformAction(Pet pet)
        {
            return true;
        }
    }
}