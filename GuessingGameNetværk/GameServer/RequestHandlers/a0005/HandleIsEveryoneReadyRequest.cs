using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.RequestHandlers
{
    class HandleIsEveryoneReadyRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0005"))
            {
                bool isEveryoneReady = true;

                foreach (User user in App.Users.Values)
                {
                    if (user.IsReady == false)
                    {
                        isEveryoneReady = false;
                    }
                }


                return $"a0005: {isEveryoneReady}";
            }

            return null;
        }
    }
}
