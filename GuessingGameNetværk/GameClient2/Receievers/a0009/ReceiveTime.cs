using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Receievers
{
    class ReceiveTime : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0009"))
            {


                App.WaitUntilCursorCanBeUsed();
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                App.IsCursorBeingUsed = true;
                request = request.Replace("a0009", "");

                App.QuestionTextBox.ReplaceLineAt(19,  $"Time until next round: {request}");

                Console.SetCursorPosition(x, y);

                App.IsCursorBeingUsed = false;


            }

            return null;
        }
    }
}
