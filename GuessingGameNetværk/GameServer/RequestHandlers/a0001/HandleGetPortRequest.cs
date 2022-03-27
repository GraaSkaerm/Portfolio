using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class HandleGetPortRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {

            if (request.Contains("a0001"))
            {
                return App.Listener.Clients[endPoint].Port.ToString();
            }

            return null;
        }
    }
}
