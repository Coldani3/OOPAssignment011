using System;

namespace OOPAssignment011
{
    public class ShopMenu : ArrowNavigableMenu
    {
        public ShopMenu()
        {
            this.AvailableActions.Add(new ActionShopItem(new ToyBall()));
            this.AvailableActions.Add(new ActionGoToMainMenu());
        }

        public override void Display()
        {
            Program.DisplayActionDescription(this.AvailableActions[this.SelectedIndex].Description);
            Console.SetCursorPosition(0, 2);
            for (int i = 0; i < this.AvailableActions.Count; i++)
            {
                if (i == this.SelectedIndex)
                {
                    Program.StartSelectWrite();
                }

                Console.WriteLine($"{i + 1}. {this.AvailableActions[i].ToString()}");

                Program.ResetConsoleColours();
            }

            Console.SetCursorPosition(Console.WindowWidth - 14, 2);
            Console.Write($"Coins: {Program.Player.PlayerInventory.Coins}");
        }

        public override void Select(int selectedIndex)
        {
            if (this.AvailableActions[selectedIndex].CanPerformAction(this.ActivePet))
            {
                this.AvailableActions[selectedIndex].Execute(this.ActivePet);
            }
        }
    }
}