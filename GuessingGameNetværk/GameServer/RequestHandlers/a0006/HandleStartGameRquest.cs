using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer.RequestHandlers
{
    class HandleStartGameRquest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0006"))
            {
               

                foreach (Client client in App.Listener.Clients.Values)
                {
                    client.Write("a0006");
                    client.GetResponse();
                }

                if (App.IsGameRunning == false)
                {
                    new Thread(App.RunGameLoop).Start();
                    App.IsGameRunning = true;
                }


            }

            return null;
        }
    }
}
