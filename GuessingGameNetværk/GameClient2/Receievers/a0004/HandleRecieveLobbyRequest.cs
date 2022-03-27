using GameClient.Menues;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Receievers
{
    class HandleRecieveLobbyRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0004"))
            {
                if (App.MenuState != MenuState.Lobby)
                {
                    return null;
                }

                App.WaitUntilCursorCanBeUsed();

                App.IsCursorBeingUsed = true;

                request = request.Remove(0, 5);
                WriteUserStates(request);
                Console.SetCursorPosition(0, 24);
                App.IsCursorBeingUsed = false;

            }

            return null;
        }

        private void WriteUserStates(string userStates)
        {
            string[] arr = userStates.Split('\n');


            for (int i = 0; i < arr.Length; i++)
            {
                App.LobbyTextBox.ReplaceLineAt(i, arr[i]);
            }
        }
    }
}
