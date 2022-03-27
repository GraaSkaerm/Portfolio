using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.RequestHandlers
{
    class HandleIsGameStartetRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0007"))
            {
                return $"a0007: {App.IsGameRunning}";
            }

            return null;
        }
    }
}
