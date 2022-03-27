using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInterface;

namespace GameClient.Menues
{
    class GameMenu : IMenu
    {
        private string _prevInput;

        public static bool OnGameInput { get; set; }

        public GameMenu()
        {
            App.QuestionTextBox = new TextBox("GAME:", new Rectangle(Console.WindowWidth - 79, 0, 40, 20));
            App.LeaderBoardTextBox = new TextBox("LEADERBOARD:", new Rectangle(0, 0, 38, 20));

            if (App.ChatTextBox == null)
            {
                Console.Clear();

                App.ChatTextBox = new TextBox("CHAT:", new Rectangle(Console.WindowWidth - 40, 0, 40, 20), InsertDirection.BottomToTop);

                App.WaitUntilCursorCanBeUsed();

                App.IsCursorBeingUsed = true;

                App.ChatTextBox.Print();

                App.IsCursorBeingUsed = false;

            }

            App.MenuState = MenuState.Game;

        }


        public void OnLoad()
        {


            App.WaitUntilCursorCanBeUsed();


            App.IsCursorBeingUsed = true;
            Console.SetCursorPosition(0, 24);

            ConsoleEditor.ClearLine(Console.WindowWidth);

            App.QuestionTextBox.Print();
            App.LeaderBoardTextBox.Print();
            App.IsCursorBeingUsed = false;


        }

        public void OnUpdate()
        {




            Thread.Sleep(100);
            App.WaitUntilCursorCanBeUsed();

            App.IsCursorBeingUsed = true;
            Console.SetCursorPosition(0, 24);

            if (_prevInput != null)
            {
                ConsoleEditor.ClearLine(_prevInput.Length);
            }

            App.IsCursorBeingUsed = false;

            OnGameInput = true;

            string input = Console.ReadLine();




            if (IsAnswer(input))
            {
                App.Client.Write("a0012");
                App.Client.GetResponse();

                App.WaitUntilCursorCanBeUsed();
                App.IsCursorBeingUsed = true;

                App.ChatTextBox.AddLine($@"You got the right answer! ""{input}""");
                App.IsCursorBeingUsed = false;

            }
            else
            {
                App.Client.Write($"a0002: {App.User.Name}: {input}");
                App.Client.GetResponse();

                App.WaitUntilCursorCanBeUsed();
                App.IsCursorBeingUsed = true;
                App.ChatTextBox.AddLine(input);
                App.IsCursorBeingUsed = false;

            }





            _prevInput = input;

        }

        private bool IsAnswer(string input)
        {
            App.Client.Write("a0011" + input);

            string response = App.Client.GetResponse();


            return response == "a0011: True";
        }
    }
}
