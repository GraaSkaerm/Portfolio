using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class InventoryMenu : BaseMenu
    {
        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.V,
            ConsoleKey.B,
        };

        protected override List<ConsoleKey> ValidUserInputs { get => validUserInputs; }

        public override void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");

            TextPrinter.Print("--- INVENTORY ---");
            TextPrinter.Print("[V]iew potions");
            TextPrinter.Print("[B]ack");

            ConsoleKey userInput = Console.ReadKey(true).Key;

            while (!ValidateUserInput(userInput))
            {
                userInput = Console.ReadKey(true).Key;
            }

            switch (userInput)
            {
                // View potions
                case ConsoleKey.V: MenuManager.CurrentMenu = new ViewPotionsMenu(); return;
                // Back
                case ConsoleKey.B: MenuManager.CurrentMenu = new GameMenu(); return;
                default: throw new Exception("Missing case for valid input: fix it");
            }
        }
    }
}
