using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.RequestHandlers
{
    class HandleUpdateLobbyRequest : IRequestHandler
    {
        private object _lock = new object();


        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0004"))
            {
                lock (_lock)
                {
                    if (request.Contains("/r"))
                    {
                        App.Users[endPoint].IsReady = !App.Users[endPoint].IsReady;
                    }

                    SendUserSatesToClients();


                }

            }


            return null;
        }

        private void SendUserSatesToClients()
        {
            string userStates = GetUserStates();

            foreach (Client client in App.Listener.Clients.Values)
            {
                client.Write(userStates);
            }
        }

        private string GetUserStates()
        {
            string userStates = "a0004";

            foreach (User user in App.Users.Values)
            {
                userStates += $"{user.ToString()}\n";
            }

            return userStates;
        }
    }
}
