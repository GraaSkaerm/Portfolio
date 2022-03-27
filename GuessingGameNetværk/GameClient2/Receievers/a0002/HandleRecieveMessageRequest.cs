using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient
{
    class HandleRecieveMessageRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {

            if (request.Contains("a0002:"))
            {

                if (App.MenuState != MenuState.Lobby)
                {
                    return null;
                }


                request = request.Remove(0, 7);

                App.ChatTextBox.AddLine(request);
                Console.SetCursorPosition(0, 24);
            }

            return null;
        }
    }
}
