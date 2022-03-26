using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class GameMenu : BaseMenu
    {
        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.O,
            ConsoleKey.P,
            ConsoleKey.B,
            ConsoleKey.Escape,
        };

        protected override List<ConsoleKey> ValidUserInputs { get => validUserInputs; }

        public override void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");

            TextPrinter.Print("--- GAME ---");
            TextPrinter.Print("[O]pen inventory");
            TextPrinter.Print("Open [P]okedex");
            TextPrinter.Print("[B]attle pokemon");
            TextPrinter.Print("ESC to logout");

            ConsoleKey userInput = Console.ReadKey(true).Key;

            while (!ValidateUserInput(userInput))
            {
                userInput = Console.ReadKey(true).Key;
            }

            switch (userInput)
            {
                // Open inventory
                case ConsoleKey.O: MenuManager.CurrentMenu = new InventoryMenu(); return;
                // Open pokedex
                case ConsoleKey.P: MenuManager.CurrentMenu = new PokedexMenu(); return;
                // Battle pokemon
                case ConsoleKey.B: MenuManager.CurrentMenu = new BattleMenu(); return;
                // Log out
                case ConsoleKey.Escape: MenuManager.CurrentMenu = new LoginMenu(); return;
                default: throw new Exception("Missing case for valid input: fix it");
            }
        }
    }
}
