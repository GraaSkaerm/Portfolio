using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class ViewPotionsMenu : BaseMenu
    {
        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.B
        };

        protected override List<ConsoleKey> ValidUserInputs { get => validUserInputs; }

        public override void ShowMenu()
        {
            Console.Clear();
            
            ShowPotions();

            Console.WriteLine();
            TextPrinter.Print("[B]ack");

            ConsoleKey userInput = Console.ReadKey(true).Key;

            while (!ValidateUserInput(userInput))
            {
                userInput = Console.ReadKey(true).Key;
            }

            switch (userInput)
            {
                case ConsoleKey.B: MenuManager.CurrentMenu = new InventoryMenu(); return;
                default: throw new Exception("Missing case for valid input: fix it");
            }
        }

        private void ShowPotions()
        {
            Console.WriteLine("\n\n\n");

            TextPrinter.Print("Here are your potions:");

            var potions = GameManager.PotionTable.GetAllWhere($"userID={GameManager.User.ID}");

            foreach (Potion potion in potions)
            {
                TextPrinter.Print($"{potion.Type} - {potion.Amount}");
            }
        }
    }
}
