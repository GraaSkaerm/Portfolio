using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.RequestHandlers
{
    class HandleIsAnswerCorrectRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0011"))
            {
                request = request.Replace("a0011", "");

                if (App.Answer == request.ToLower())
                {
                    return "a0011: True";
                }

                return "a0011: False";
            }

            return null;
        }
    }
}
