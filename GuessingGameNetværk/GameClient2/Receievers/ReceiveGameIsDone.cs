using GameClient.Menues;
using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClient.Receievers
{
    class ReceiveGameIsDone : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0013"))
            {

                App.IsGameRunning = false;
                App.Menu = new LobbyMenu();
                App.AbortReadline(0);

            }


            return null;
        }
    }
}
