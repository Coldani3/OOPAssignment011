namespace OOPAssignment011
{
    public class ActionQuit : Action
    {
        public ActionQuit() : base("Quit", "Quit out of the simulator.")
        {
            
        }

        public override bool Execute(Pet pet)
        {
            Program.Running = false;
            return true;
        }
    }
}