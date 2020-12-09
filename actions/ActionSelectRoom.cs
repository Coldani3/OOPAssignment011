namespace OOPAssignment011
{
    public class ActionSelectRoom : Action
    {
        private Room room;
        public ActionSelectRoom(Room room) : base(room.Name, room.Description)
        {
            this.room = room;
        }

        public override bool Execute(Pet pet)
        {
            pet.Room = this.room;
            Program.GotoMainMenu();
            return true;
        }
    }
}