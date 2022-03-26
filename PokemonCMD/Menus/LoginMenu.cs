using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PokemonCMD
{
    class LoginMenu : BaseMenu
    {
        private List<ConsoleKey> validUserInputs = new List<ConsoleKey>()
        {
            ConsoleKey.L,
            ConsoleKey.C,
        };

        protected override List<ConsoleKey> ValidUserInputs { get => validUserInputs; }

        public LoginMenu()
        {
        }

        public override void ShowMenu()
        {
            Console.Clear();

            //margin
            Console.WriteLine("\n\n\n");

            TextPrinter.Print("--- LOGIN ---");

            TextPrinter.Print("[L]ogin or [C]reate user?");
            ConsoleKey userInput = Console.ReadKey(true).Key;


            while (!ValidateUserInput(userInput))
            {
                userInput = Console.ReadKey(true).Key;
            }

            switch (userInput)
            {
                // Login
                case ConsoleKey.L: Login(); break;
                // Create user
                case ConsoleKey.C: CreateUser(); break;
                default: throw new Exception("Missing case for valid input: fix it");
            }

            // Change state
            //MenuManager.CurrentMenu = new GameMenu();
        }

        private void CreateUser()
        {
            string username = default;

            while (username == default || UsernameExists(username))
            {
                Console.Clear();
                Console.WriteLine("\n\n\n");
                TextPrinter.Print("--- CREATE USER ---");

                if (username != default)
                {
                    TextPrinter.Print("Username already taken please try again...");
                    TextPrinter.Print("Enter username:");
                }
                else
                {
                    TextPrinter.Print("press ESC to go back");
                    TextPrinter.Print("Enter username:");
                }

                StringBuilder buffer = new StringBuilder();
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                GetInput(ref buffer, ref key);

                switch (key.Key)
                {
                    case ConsoleKey.Escape: MenuManager.CurrentMenu = new LoginMenu(); return;
                    case ConsoleKey.Enter: username = buffer.ToString(); break;
                }
            }

            string password = default;

            while (!IsPasswordValid(password))
            {
                if (password != default)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n");
                    TextPrinter.Print("-- CREATE USER ---");
                    TextPrinter.Print("Not a valid password");
                }
                Console.WriteLine();
                TextPrinter.Print("Enter password:");

                StringBuilder buffer = new StringBuilder();
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                GetInput(ref buffer, ref key);

                switch (key.Key)
                {
                    case ConsoleKey.Escape: MenuManager.CurrentMenu = new LoginMenu(); return;
                    case ConsoleKey.Enter: password = buffer.ToString(); break;
                }
            }

            GameManager.UserTable.Add(new User(username, password));
            GameManager.User = GameManager.UserTable.Get($"name='{username}'");

            GiveStartingItems();

            Console.WriteLine("\n");
            TextPrinter.Print($"Welcome {username}");

            Thread.Sleep(1000);

            MenuManager.CurrentMenu = new GameMenu();
        }

        private void GiveStartingItems()
        {
            for (int i = 0; i < 3; i++)
            {
                GameManager.PokemonTable.Add(new Pokemon(GameManager.User.ID));
            }

            foreach (PotionType potion in Enum.GetValues(typeof(PotionType)))
            {
                GameManager.PotionTable.Add(new Potion(GameManager.User.ID, potion, 1));
            }
        }

        private void Login()
        {
            string username = default;

            while (!UsernameExists(username))
            {
                Console.Clear();
                Console.WriteLine("\n\n\n");
                TextPrinter.Print("--- LOGIN TO USER ---");

                if (username != default)
                {
                    TextPrinter.Print("no account with that username exists, please try again...");
                }
                else
                {
                    TextPrinter.Print("press ESC to go back");
                }
                
                TextPrinter.Print("Enter your username:");

                StringBuilder buffer = new StringBuilder();
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                GetInput(ref buffer, ref key);

                switch (key.Key)
                {
                    case ConsoleKey.Escape: MenuManager.CurrentMenu = new LoginMenu(); return;
                    case ConsoleKey.Enter: username = buffer.ToString(); break;
                }
            }

            string password = default;

            while (!IsAssociatedPassword(username, password))
            {
                if (password != default)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n");

                    TextPrinter.Print("--- LOGIN TO USER ---");
                    TextPrinter.Print("password doesnt match username, please try again...");
                    TextPrinter.Print("Enter your password:");
                }
                else
                {
                    Console.WriteLine();
                    TextPrinter.Print("Enter your password:");
                }

                StringBuilder buffer = new StringBuilder();
                ConsoleKeyInfo key = new ConsoleKeyInfo();
                GetInput(ref buffer, ref key);

                switch (key.Key)
                {
                    case ConsoleKey.Escape: MenuManager.CurrentMenu = new LoginMenu(); return;
                    case ConsoleKey.Enter: password = buffer.ToString(); break;
                }
            }

            GameManager.User = GameManager.UserTable.Get($"name='{username}'");

            MenuManager.CurrentMenu = new GameMenu();
        }

        /// <summary>
        /// Get input from user. Stops when user hits the "Escape" key or the "Enter" key
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="key"></param>
        private void GetInput(ref StringBuilder buffer, ref ConsoleKeyInfo key)
        {
            key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape && key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (buffer.Length > 0)
                    {
                        Console.Write(" \b");
                        buffer.Remove(buffer.Length - 1, 1);
                    }
                }
                else
                    buffer.Append(Convert.ToChar(key.KeyChar));

                key = Console.ReadKey();
            }
        }

        private bool IsPasswordValid(string password)
        {
            if (password != string.Empty && password != default)
                return true;
            else
                return false;
        }

        private bool IsAssociatedPassword(string username, string password)
        {
            if (GameManager.UserTable.Get($"name='{username}'").Password == password)
                return true;
            else
                return false;
        }

        private bool UsernameExists(string username)
        {
            var user = GameManager.UserTable.Get($"name='{username}'");
            if (user != null)
                return true;
            else
                return false;
        }
    }
}
