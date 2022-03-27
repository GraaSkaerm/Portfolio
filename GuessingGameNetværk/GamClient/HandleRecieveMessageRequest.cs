using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamClient
{
    class HandleRecieveMessageRequest : IRequestHandler
    {
        public string GetResponse(string endPoint, string request)
        {

            if (request.Contains("a0002:"))
            {
                request = request.Remove(0, 5);

                App.Chat.AddLine(request);
            }

            return null;
        }
    }
}
