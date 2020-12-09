namespace OOPAssignment011
{
    public class ActionPreviousMenu : Action
    {
        public ActionPreviousMenu() : base("Go Back", "Return to the previous menu")
        {

        }
        
        public override bool Execute(Pet pet)
        {
            Program.GoToPreviousMenu();
            return true;
        }
    }
}