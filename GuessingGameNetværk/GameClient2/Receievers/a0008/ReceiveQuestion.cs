using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Receievers
{
    class ReceiveQuestion : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0008"))
            {
                App.WaitUntilCursorCanBeUsed();

                App.IsCursorBeingUsed = true;

                App.QuestionTextBox.ClearAllLines();

                request = request.Replace("a0008", "");
                App.QuestionTextBox.AddLine(request);

                Console.SetCursorPosition(0, 24);

                App.IsCursorBeingUsed = false;

            }

            return null;
        }
    }
}
