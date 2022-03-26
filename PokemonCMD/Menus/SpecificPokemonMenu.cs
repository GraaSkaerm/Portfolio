using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class SpecificPokemonMenu : BaseMenu
    {
        Pokemon viewPokemon;

        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.B,
            ConsoleKey.U,
            ConsoleKey.R
        };

        protected override List<ConsoleKey> ValidUserInputs => validUserInputs;

        public SpecificPokemonMenu(Pokemon pokemonToView)
        {
            this.viewPokemon = pokemonToView;
        }

        public override void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");

            TextPrinter.Print($"Name: {viewPokemon.Name}");
            TextPrinter.Print($"Level: {viewPokemon.Level}");
            TextPrinter.Print($"MaxHealth: {viewPokemon.MaxHealth}");
            TextPrinter.Print($"Health: {viewPokemon.Health}");
            TextPrinter.Print($"Damage: {viewPokemon.Damage}");
            TextPrinter.Print($"Speed: {viewPokemon.Speed}");

            Console.WriteLine();
            TextPrinter.Print($"[U]se potion");
            TextPrinter.Print($"[B]ack");

            var userInput = Console.ReadKey(true);

            while (!ValidateUserInput(userInput.Key))
            {
                userInput = Console.ReadKey(true);
            }

            switch (userInput.Key)
            {
                case ConsoleKey.B: MenuManager.CurrentMenu = new PokedexMenu(); return;
                case ConsoleKey.U: MenuManager.CurrentMenu = new UsePotionMenu(this, viewPokemon); return;
            }
        }
    }
}
