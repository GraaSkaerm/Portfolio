using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Receievers
{
    class ReceiveLeaderBoard : IRequestHandler
    {
        private object _lock = new object();

        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0010"))
            {
                lock (_lock)
                {
                    while (App.MenuState != MenuState.Game)
                    {

                    }

                    request = request.Replace("a0010", "");

                    string[] arr = request.Split('\n');

                    App.WaitUntilCursorCanBeUsed();

                    App.IsCursorBeingUsed = true;



                    for (int i = 0; i < arr.Length; i++)
                    {
                        App.LeaderBoardTextBox.ReplaceLineAt(i, arr[i]);
                    }

                    Console.SetCursorPosition(0, 24);

                    App.IsCursorBeingUsed = false;
                }

                

            }

            return null;
        }
    }
}
