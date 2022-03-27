using GameClient.Menues;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserInterface;

namespace GameClient
{
    class LoginMenu : IMenu
    {
        private TextBox _appTextBox;
        private TextBox _logTextBox;

        private string _prevInput;

        public LoginMenu()
        {
            Console.CursorVisible = true;
            _logTextBox = new TextBox("LOG:", new Rectangle(Console.WindowWidth / 2 - 20, 6, 40, 10));
            _appTextBox = new TextBox("APP STATE:", new Rectangle(Console.WindowWidth / 2 - 20, 0, 40, 1));
        }

        public void OnLoad()
        {
            App.MenuState = MenuState.Login;

            Console.Clear();
            _appTextBox.AddLine("Please enter name...");
            _logTextBox.Print();
            _appTextBox.Print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 20);
        }

        public void OnUpdate()
        {
            App.WaitUntilCursorCanBeUsed();

            App.IsCursorBeingUsed = true;

            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 20);

            if (_prevInput != null)
            {
                ConsoleEditor.ClearLine(_prevInput.Length);
            }
            App.IsCursorBeingUsed = false;


            string input = Console.ReadLine();
            _prevInput = input;




            if (IsNameValid(input) == true)
            {
                App.Menu = new LobbyMenu();
                App.User = new User() { Name = input };
            }

        }

        private bool IsNameValid(string name)
        {
            if (ContainsSpecielCharacters(name))
            {
                _logTextBox.ClearAllLines();
                _logTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: No special characters.");
                return false;
            }

            if (IsNameTooShort(name))
            {
                _logTextBox.ClearAllLines();
                _logTextBox.AddLine($@"{DateTime.Now.ToString("HH:mm:ss tt")}: Min ""1"" character long.");
                return false;
            }

            if (IsNameTooLong(name))
            {
                _logTextBox.ClearAllLines();
                _logTextBox.AddLine($@"{DateTime.Now.ToString("HH:mm:ss tt")}: Max ""16"" character long.");
                return false;
            }

            if (IsNameTaken(name))
            {
                _logTextBox.ClearAllLines();
                _logTextBox.AddLine($@"{DateTime.Now.ToString("HH:mm:ss tt")}: Name is taken.");
                return false;
            }


            return true;
        }

        private bool IsNameTaken(string name)
        {
            App.Client.Write($"a0003: {name}");
            string response = App.Client.GetResponse();

            return response == "a0003: NOT VALID";
        }

        private bool IsNameTooShort(string name)
        {
            return name.Length < 1;
        }

        private bool IsNameTooLong(string name)
        {
            return name.Length >= 17;
        }

        private bool ContainsSpecielCharacters(string name)
        {
            Regex rgx = new Regex("[^A-Za-z0-9]");
            return rgx.IsMatch(name);
        }

       
    }
}
