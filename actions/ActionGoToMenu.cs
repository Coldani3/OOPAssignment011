namespace OOPAssignment011
{
    public class ActionGoToMenu : Action
    {
        private Menu menu;
        public ActionGoToMenu(string name, string description, Menu menu) : base(name, description)
        {
            this.menu = menu;
        }

        public override bool Execute(Pet pet)
        {
            this.menu.ActivePet = pet;
            this.menu.CurrentPlayer = Program.Player;
            Program.ChangeMenu(this.menu);
            return true;
        }
    }
}