using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace PokemonCMD
{
   class FightingMenu : BaseMenu
    {
        bool isShowingBattle;
        Pokemon playerPokemon;
        Pokemon enemyPokemon;
        int playerPokemonStamina = 10;
        int enemyPokemonStamina = 10;

        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.S,
            ConsoleKey.V
        };

        protected override List<ConsoleKey> ValidUserInputs { get => validUserInputs; }

        public FightingMenu(Pokemon playerPokemon, Pokemon enemyPokemon)
        {
            this.playerPokemon = playerPokemon;
            this.enemyPokemon = enemyPokemon;
        }

        public override void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            TextPrinter.Print($"Your pokemon: {playerPokemon.Name} - lvl: {playerPokemon.Level} - dmg: {playerPokemon.Damage} - HP: {playerPokemon.Health}");
            TextPrinter.Print($"Enemy pokemon: {enemyPokemon.Name} - lvl: {enemyPokemon.Level} - dmg: {enemyPokemon.Damage} - HP: {enemyPokemon.Health}\n");
            TextPrinter.Print("[V]iew battle");
            TextPrinter.Print("[S]kip battle");

            var userinput = Console.ReadKey(true);

            while (!ValidateUserInput(userinput.Key))
            {
                userinput = Console.ReadKey(true);
            }

            switch (userinput.Key)
            {
                case ConsoleKey.V: isShowingBattle = true; break;
                case ConsoleKey.S: isShowingBattle = false; break;
                default: throw new Exception("Missing case for valid input: fix it");
            }

            Console.Clear();

            Fight();

            Console.WriteLine("\n");
            TextPrinter.Print("Press any key to return to the battle menu");
            Console.ReadKey(true);
        }

        private void Fight()
        {
            while (playerPokemon.Health > 0 && enemyPokemon.Health > 0)
            {
                if (playerPokemonStamina > 9)
                {
                    enemyPokemon.Health -= playerPokemon.Damage;
                    playerPokemonStamina -= 10;
                }

                if (enemyPokemonStamina > 9)
                {
                    playerPokemon.Health -= enemyPokemon.Damage;
                    enemyPokemonStamina -= 10;
                }

                playerPokemonStamina += playerPokemon.Speed;
                enemyPokemonStamina += enemyPokemon.Speed;

                if (isShowingBattle)
                {
                    ShowCombat();
                    Thread.Sleep(1000);
                }
            }

            if (playerPokemon.Health > 0)
                PlayerWon();
            else
                EnemyWon();
        }

        private void EnemyWon()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            TextPrinter.Print("condolences your pokemon Lost...");
            GameManager.PokemonTable.Update(playerPokemon);
            MenuManager.CurrentMenu = new BattleMenu();
        }

        private void PlayerWon()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            TextPrinter.Print("Congratulations your pokemon won!");
            BattleRewards();
            MenuManager.CurrentMenu = new BattleMenu(playerPokemon);
        }

        private void ShowCombat()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            TextPrinter.Print("Players Pokemon", TextAlignment.Left);
            TextPrinter.Print($"{playerPokemon.Name}", TextAlignment.Left);
            TextPrinter.Print($"HP: {playerPokemon.Health}", TextAlignment.Left);
            TextPrinter.Print($"Stamina: {playerPokemonStamina}", TextAlignment.Left);

            TextPrinter.Print("Enemy Pokemon", TextAlignment.Right);
            TextPrinter.Print($"{enemyPokemon.Name}", TextAlignment.Right);
            TextPrinter.Print($"HP: {enemyPokemon.Health}", TextAlignment.Right);
            TextPrinter.Print($"Stamina: {enemyPokemonStamina}", TextAlignment.Right);
        }

        private void AddToInventory(Potion potion)
        {
            Potion usersPotion = GameManager.PotionTable.Get($"type = '{potion.Type}' AND userid = '{GameManager.User.ID}'");
            usersPotion.Amount += potion.Amount;
            GameManager.PotionTable.Update(usersPotion);
        }

        private void AddToInventory(Pokemon pokemon)
        {
            GameManager.PokemonTable.Add(pokemon);
        }

        private Potion GetRandomPotion()
        {
            Array potionTypes = Enum.GetValues(typeof(PotionType));

            var rnd = new Random();
            PotionType rndPotionType = (PotionType)potionTypes.GetValue(rnd.Next(potionTypes.Length));

            Potion potion = new Potion(GameManager.User.ID, rndPotionType, 1);

            return potion;
        }

        /// <summary>
        /// Get a random level 1 pokemon
        /// </summary>
        /// <returns>Pokemon</returns>
        private Pokemon GetRandomPokemon()
        {
            Pokemon rndPokemon = new Pokemon(GameManager.User.ID);

            return rndPokemon;
        }

        //The rewards the player receives after winning the pokemon battle.
        private void BattleRewards()
        {
            Random rnd = new Random();

            for (int i = 0; i < rnd.Next(1, 4); i++)
            {
                Potion potion = GetRandomPotion();
                AddToInventory(potion);
                TextPrinter.Print($"You won a potion: {potion.Type}");
            }

            if (rnd.Next(0, 11) > 7)
            {
                Pokemon pokemon = GetRandomPokemon();
                AddToInventory(pokemon);
                TextPrinter.Print($"You won a new pokemon: {pokemon.Name}");
            }

            TextPrinter.Print("Your Pokemon Gained a level!");
            playerPokemon.LevelUp();
            GameManager.PokemonTable.Update(playerPokemon);
        }
    }
}
