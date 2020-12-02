namespace OOPAssignment011
{
    public class ActionGoToMainMenu : ActionGoToMenu
    {
        public ActionGoToMainMenu() : base("To Main Menu", "Go back to the main menu with your pet.", Program.MainMenu)
        {

        }

        public override bool Execute(Pet pet)
        {
            Program.GotoMainMenu();
            return true;
        }
    }
}