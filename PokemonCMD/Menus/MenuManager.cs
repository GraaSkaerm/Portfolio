using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    static class MenuManager
    {
        /// <summary>
        /// Current menu displaying
        /// </summary>
        public static IMenu CurrentMenu { get; set; }

        public static void ShowCurrentMenu()
        {
            CurrentMenu.ShowMenu();
        }
    }
}
