using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    public abstract class BaseMenu : IMenu
    {
        protected abstract List<ConsoleKey> ValidUserInputs { get; }

        public abstract void ShowMenu();

        protected bool ValidateUserInput(ConsoleKey userInput)
        {
            return ValidUserInputs.Contains(userInput);
        }
    }
}
