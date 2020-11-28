namespace OOPAssignment011
{
    public class ActionQuit : Action
    {
        public ActionQuit(string name, string description) : base(name, description)
        {
            
        }

        public override bool Execute(Pet pet)
        {
            Program.Running = false;
            return true;
        }
    }
}