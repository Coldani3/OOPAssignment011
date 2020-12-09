namespace OOPAssignment011
{
    public class SelectRoomMenu : ArrowNavigableMenu
    {
        public SelectRoomMenu()
        {
            foreach (Room room in Program.Rooms)
            {
                this.AvailableActions.Add(new ActionSelectRoom(room));
            }

            this.AvailableActions.Add(new ActionGoToMainMenu());
        }
    }
}