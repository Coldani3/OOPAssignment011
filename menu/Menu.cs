using System;
using System.Collections.Generic;

namespace OOPAssignment011
{
    public abstract class Menu
    {
        public List<Action> AvailableActions = new List<Action>();
        public Pet ActivePet;
        public Player CurrentPlayer;

        public abstract void HandleInput(ConsoleKeyInfo key);
        public abstract void Display();

    }
}