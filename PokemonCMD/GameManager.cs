using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    static class GameManager
    {
        private static bool isGameRunning;

        private static DataBase dataBase;
        public static UserTable UserTable { get; private set; }
        public static PotionTable PotionTable { get; set; }
        public static PokemonTable PokemonTable { get; set; }
        public static PokedexTable PokedexTable { get; set; }

        public static bool IsGameRunning { get => isGameRunning; set => isGameRunning = value; }

        /// <summary>
        /// Currently logged in user
        /// </summary>
        public static User User { get; set; }

        public static void StartGame()
        {
            dataBase = new DataBase("GameDataBase");
            UserTable = new UserTable(dataBase, "Users");
            PotionTable = new PotionTable(dataBase, "Potions");
            PokemonTable = new PokemonTable(dataBase, "Pokemons");
            PokedexTable = new PokedexTable(dataBase, "Pokedex");

            MenuManager.CurrentMenu = new LoginMenu();
            IsGameRunning = true;

            while (IsGameRunning)
            {
                MenuManager.ShowCurrentMenu();
            }

            EndGame();
        }

        private static void EndGame()
        {
            Console.WriteLine("Ending game");
        }
    }
}
