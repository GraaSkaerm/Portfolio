using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace PokemonCMD
{
    class UsePotionMenu : BaseMenu
    {
        BaseMenu previusMenu;
        Pokemon selectedPokemon;

        List<Potion> userPotions = GameManager.PotionTable.GetAllWhere($"userID = '{GameManager.User.ID}'").ToList();
        Dictionary<ConsoleKey, Potion> potionReference = new Dictionary<ConsoleKey, Potion>();

        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.B,
        };

        protected override List<ConsoleKey> ValidUserInputs { get => validUserInputs; }

        public UsePotionMenu(BaseMenu previusMenu, Pokemon selectedPokemon)
        {
            this.selectedPokemon = selectedPokemon;
            this.previusMenu = previusMenu;
        }

        public override void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            ShowPotions();

            TextPrinter.Print($"[B]ack");
            ConsoleKey userInput = Console.ReadKey(true).Key;

            while (!ValidateUserInput(userInput) && !potionReference.ContainsKey(userInput))
            {
                userInput = Console.ReadKey(true).Key;
            }

            if (potionReference.ContainsKey(userInput))
            {
                potionReference[userInput].Amount -= 1;
                GameManager.PotionTable.Update(potionReference[userInput]);
                potionReference[userInput].UseOn(selectedPokemon);

                GameManager.PokemonTable.Update(selectedPokemon);

                TextPrinter.Print($"{potionReference[userInput].Type} was used on {selectedPokemon.Name}...");
                Thread.Sleep(1000);
                MenuManager.CurrentMenu = previusMenu; return;
            }

            switch (userInput)
            {
                case ConsoleKey.B: MenuManager.CurrentMenu = previusMenu; return;
                default: throw new Exception("Missing case for valid input: fix it");
            }
        }

        private void ShowPotions()
        {
            TextPrinter.Print("Your potions:");

            for (int i = 0; i < userPotions.Count; i++)
            {
                TextPrinter.Print($"[{i + 1}] {userPotions[i].Type} {userPotions[i].Amount} ");

                if (userPotions[i].Amount > 0)
                {
                    ConsoleKey ck;
                    Enum.TryParse<ConsoleKey>("D" + (i + 1).ToString(), out ck);
                    potionReference.Add(ck, userPotions[i]);
                }
            }
        }
    }
}
