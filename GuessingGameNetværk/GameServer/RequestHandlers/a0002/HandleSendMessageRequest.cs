using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class HandleSendMessageRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0002:"))
            {

                foreach (var client in App.Listener.Clients.Values)
                {
                    if (App.Listener.Clients[endPoint] != client)
                    {
                        client.Write(request);
                        client.GetResponse();
                    }

                   
                }
            }


            return null;
        }
    }
}
