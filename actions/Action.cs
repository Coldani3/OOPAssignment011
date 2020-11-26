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

        public virtual bool Execute()
        {
            return false;
        }

        public virtual bool CanPerformAction()
        {
            return true;
        }
    }
}