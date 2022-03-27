using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace GameClient.Menues
{
    class LobbyMenu : IMenu
    {


        private string _prevInput;

        public LobbyMenu()
        {
            App.LogTextBox = new TextBox("LOG:", new Rectangle(0, 0, 38, 20));
            App.LobbyTextBox = new TextBox("LOBBY:", new Rectangle(Console.WindowWidth - 79, 0, 40, 20));
            App.ChatTextBox = new TextBox("CHAT:", new Rectangle(Console.WindowWidth - 40, 0, 40, 20), InsertDirection.BottomToTop);
        }

        public void OnLoad()
        {
            App.MenuState = MenuState.Lobby;

            Console.Clear();

            App.WaitUntilCursorCanBeUsed();

            App.IsCursorBeingUsed = true;
            App.LogTextBox.Print();
            App.ChatTextBox.Print();
            App.LobbyTextBox.Print();

           
            App.Client.Write("a0004");
            App.Client.GetResponse();

            App.LogTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: \"/help\" to see commands.");


            Console.SetCursorPosition(0, 24);
            App.IsCursorBeingUsed = false;

        }

        public void OnUpdate()
        {
            start:

            App.WaitUntilCursorCanBeUsed();

            App.IsCursorBeingUsed = true;
            Console.SetCursorPosition(0, 24);

            if (_prevInput != null)
            {
                ConsoleEditor.ClearLine(_prevInput.Length);
            }

            App.IsCursorBeingUsed = false;


            if (App.IsGameRunning == true)
            {
                return;
            }

            string input = Console.ReadLine();


            _prevInput = input;

            if (input == "")
            {
                goto start;
            }

            if (input[0] == '/')
            {

                if (input.ToLower() == "/r")
                {
                    App.Client.Write($"a0004: /r");
                    App.Client.GetResponse();



                    goto start;
                }

                if (input.ToLower() == "/help")
                {
                    App.LogTextBox.ClearAllLines();
                    App.LogTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: \"/r\" -> ready up.");
                    App.LogTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: \"/s\" -> starts the game.");
                    goto start;
                }


                if (input.ToLower() == "/s")
                {
                    App.Client.Write("a0005: IsEveryoneReady");

                    string s = App.Client.GetResponse();



                    if (s == "a0005: True")
                    {
                        App.Client.Write("a0006: StartGame");
                        App.Client.GetResponse();
                        return;
                    }

                    App.LogTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: Everyone has to be ready.");

                    goto start;
                }

                App.LogTextBox.ClearAllLines();
                App.LogTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: Command not valid.");
                App.LogTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: \"/help\" to see commands.");
                goto start;

            }
            else
            {
                if (DoesMessageHaveToManySpaces(input))
                {
                    App.LogTextBox.ClearAllLines();
                    App.LogTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: \"/help\" to see commands.");
                    App.LogTextBox.AddLine($"{DateTime.Now.ToString("HH:mm:ss tt")}: Too many spaces.");
                    goto start;
                }

                App.Client.Write($"a0002: {App.User.Name}: {input}");
                App.Client.GetResponse();
                App.ChatTextBox.AddLine(input);

            }



        }

        private bool DoesMessageHaveToManySpaces(string message)
        {
            string[] arr = message.Split(' ');

            return arr.Length > 30;
        }



    }
}
