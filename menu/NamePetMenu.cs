using System;

namespace OOPAssignment011
{
    public class NamePetMenu : Menu 
    {
        private string inputField = "";
        private int cursorIndex = 0;
        private Pet pet;

        public NamePetMenu(Pet pet)
        {
            this.pet = pet;
            this.inputField = pet.Name;
            this.cursorIndex = pet.Name.Length - 1;
        }

        public override void Display()
        {
            Program.DisplayActionDescription("Enter the new name for your pet!");
        }

        public override void HandleInput(ConsoleKeyInfo key)
        {
            char keyChar = key.KeyChar;
            //manually implementing an input so that we can have the previous pet name be already in the input field
            if (((int) keyChar) > 31 && ((int) keyChar) < 256)
            {
                this.inputField.Insert(this.cursorIndex, keyChar.ToString());
                this.cursorIndex++;
            }
            else
            {
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                    //delete character before cursorIndex
                        string after = this.inputField.Substring(this.cursorIndex);
                        string before = this.inputField.Substring(0, cursorIndex - 1);
                        this.inputField = before + after;
                        break;
                    
                    case ConsoleKey.LeftArrow:
                        if ((key.Modifiers & ConsoleModifiers.Control) != 0)
                        {
                            this.cursorIndex = 0;
                        }
                        else
                        {
                            this.cursorIndex--;
                        }
                        break;
                    
                    case ConsoleKey.RightArrow:
                        if ((key.Modifiers & ConsoleModifiers.Control) != 0)
                        {
                            this.cursorIndex = this.inputField.Length - 1;
                        }
                        else
                        {
                            this.cursorIndex++;
                        }
                        break;
                    
                    case ConsoleKey.Enter:
                        this.pet.Name = this.inputField;
                        break;
                }
                
            }

            throw new NotImplementedException();
        }
    }
}