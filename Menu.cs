using System;
using System.Collections.Generic;

namespace OOPAssignment011
{
    public class Menu
    {
        public List<Action> AvailableActions = new List<Action>();
        public Pet ActivePet;
        public Player CurrentPlayer;

        public void Display()
        {
            //Display last
            this.DisplaySelectMenu();
        }

        private void DisplaySelectMenu()
        {

        }
    }
}