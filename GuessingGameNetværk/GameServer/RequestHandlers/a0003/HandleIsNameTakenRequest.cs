using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.RequestHandlers
{
    class HandleIsNameTakenRequest : IRequestHandler
    {
        private object lockObject = new object();

        public HandleIsNameTakenRequest()
        {
            App.Users = new Dictionary<string, User>();
        }

        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0003:"))
            {
                lock (lockObject)
                {
                    foreach (var key in App.Users.Keys)
                    {
                        if (App.Listener.Clients.ContainsKey(key) == false)
                        {
                            App.Users.Remove(key);
                        }
                    }
                }

                request = request.Replace("a0003: ", "");

                foreach (User user in App.Users.Values)
                {
                    if (user.Name == request)
                    {
                        return "a0003: NOT VALID";
                    }
                }



                App.Users.Add(endPoint, new User() { Name = request });

                return "a0003: VALID";
            }

            return null;
        }
    }
}
