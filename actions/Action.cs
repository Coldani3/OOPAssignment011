namespace OOPAssignment011
{
    public class Action
    {
        public string Name;
        public string Description;

        public virtual bool Execute()
        {
            return false;
        }
    }
}