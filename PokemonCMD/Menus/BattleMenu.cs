using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class BattleMenu : BaseMenu
    {
        Pokemon selectedPokemon;

        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.B,
            ConsoleKey.C,
            ConsoleKey.D1,
            ConsoleKey.D2,
            ConsoleKey.D3,
            ConsoleKey.D4,
        };

        protected override List<ConsoleKey> ValidUserInputs { get => validUserInputs; }

        public BattleMenu()
        { 
        }

        public BattleMenu(Pokemon selectedPokemon)
        {
            this.selectedPokemon = selectedPokemon;
        }

        public override void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");

            TextPrinter.Print("--- BATTLE MENU ---");

            if (selectedPokemon != null)
                TextPrinter.Print($"{selectedPokemon.Name} lvl:{selectedPokemon.Level} HP: {selectedPokemon.Health} is currently selected...");
            else
                TextPrinter.Print("You must choose a pokemon before you can enter a fight");

            TextPrinter.Print("[C]hoose pokemon to fight for you.\n");
            TextPrinter.Print("[1]fight random low level pokemon (1-2)");
            TextPrinter.Print("[2]fight random Medium level pokemon. (3-5)");
            TextPrinter.Print("[3]fight random high level pokemon (6-8)");
            TextPrinter.Print("[4]fight random very high level pokemon (9-12)\n");
            TextPrinter.Print("[B]ack.");
            ConsoleKey userinput = Console.ReadKey(true).Key;

            while (!ValidateUserInput(userinput))
            {
                userinput = Console.ReadKey(true).Key;
            }

            switch (userinput)
            {
                case ConsoleKey.C: MenuManager.CurrentMenu = new ChooseFigtherMenu(); return;
                case ConsoleKey.B: MenuManager.CurrentMenu = new GameMenu(); return;
                case ConsoleKey.D1: SpawnFightingMenu(1, 3); return;
                case ConsoleKey.D2: SpawnFightingMenu(3, 6); return;
                case ConsoleKey.D3: SpawnFightingMenu(6, 9); return;
                case ConsoleKey.D4: SpawnFightingMenu(9, 13); return;
                default: throw new Exception("Missing case for valid input: fix it");
            }
        }

        /// <summary>
        /// Change current menu to Fighting menu if selectedPokemon is not null else 'reload' Battle menu
        /// </summary>
        /// <param name="minLevel">Minimum level of enemy pokemon</param>
        /// <param name="maxLevel">Maximum level of enemy pokemon</param>
        private void SpawnFightingMenu(int minLevel, int maxLevel)
        {
            if (selectedPokemon != null)
                MenuManager.CurrentMenu = new FightingMenu(selectedPokemon, new Pokemon(level: new Random().Next(minLevel, maxLevel)));
            else
                MenuManager.CurrentMenu = new BattleMenu();
        }
    } 
}
