using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class MainMenu : IMenu
    {





        public void OnLoad()
        {
            App.MenuState = MenuState.Main;

            Console.CursorVisible = false;

            Console.WriteLine(@"""P"" -> Play  ");
        }

        public void OnUpdate()
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.P: App.Menu = new LoginMenu(); break;
                default: break;
            }

        }

       
    }
}
