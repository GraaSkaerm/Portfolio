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
    class HandleIsGameStartetRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0006"))
            {

                App.IsGameRunning = true;

                App.Menu = new GameMenu();

                App.AbortReadline(0);
            }


            return null;
        }
    }
}
