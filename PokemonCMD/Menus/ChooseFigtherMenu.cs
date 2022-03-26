using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokemonCMD
{
    public class ChooseFigtherMenu : BaseMenu
    {
        private int indexStart = 0;
        private int page = 1;

        public int Page
        {
            get { return page; }
            set
            {
                page = value;
                indexStart = page * 9 - 9;
            }
        }

        List<Pokemon> userPokemons = GameManager.PokemonTable.GetAllWhere($"userID = '{GameManager.User.ID}'").ToList();

        Dictionary<ConsoleKey, Pokemon> pokemonReference = new Dictionary<ConsoleKey, Pokemon>();

        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.RightArrow,
            ConsoleKey.LeftArrow,
            ConsoleKey.B,
        };

        protected override List<ConsoleKey> ValidUserInputs { get => validUserInputs; }


        public override void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            TextPrinter.Print(" Welcome to your pokedex. Your pokedex is an overview of all your Pokemons. ");
            TextPrinter.Print($"Navigate pages via arrow keys.");
            TextPrinter.Print($"page: {Page}");

            ShowPokemons(userPokemons);

            Console.WriteLine();
            TextPrinter.Print($"[B]ack");

            ConsoleKey userInput = Console.ReadKey(true).Key;

            while (!ValidateUserInput(userInput) && !pokemonReference.ContainsKey(userInput))
            {
                userInput = Console.ReadKey(true).Key;
            }

            if (pokemonReference.ContainsKey(userInput))
            {
                MenuManager.CurrentMenu = new BattleMenu(pokemonReference[userInput]);
            }
            else
            {
                switch (userInput)
                {
                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        if (userPokemons.Count > indexStart + 1)
                            Page++;
                        ShowMenu();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (indexStart > 0)
                            Page--;
                        ShowMenu();
                        break;
                    case ConsoleKey.B: MenuManager.CurrentMenu = new BattleMenu(); return;
                    default: throw new Exception();
                }
            }
        }

        private void ShowPokemons(List<Pokemon> userPokemons)
        {
            pokemonReference.Clear();

            for (int i = indexStart; i < userPokemons.Count; i++)
            {
                if (i < indexStart + 9)
                {
                    TextPrinter.Print($"[{i + 1 - indexStart}] {userPokemons[i].Name} - lvl: {userPokemons[i].Level}, HP: {userPokemons[i].Health}");

                    if (userPokemons[i].Health > 0)
                    {
                        ConsoleKey ck;
                        Enum.TryParse<ConsoleKey>("D" + (i + 1 - indexStart).ToString(), out ck);

                        pokemonReference.Add(ck, userPokemons[i]);
                    }
                }
                else
                    break;
            }
        }

    }
}
