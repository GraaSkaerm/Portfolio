using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.RequestHandlers
{
    class HandleGetPointsRequest : IRequestHandler
    {
        private int _prevRound;

        private List<string> _gotPoints;
        private int _requestCount;
        private int _points = 500;


        public string GetResponse(string endPoint, string request)
        {
            if (request.Contains("a0012"))
            {
                if (_prevRound != App.Round)
                {
                    _prevRound = App.Round;
                    _requestCount = 0;
                    _gotPoints = new List<string>();
                }



                if (_gotPoints.Contains(endPoint) == false)
                {
                    App.Users[endPoint].Score += _points - (50 * _requestCount);

                    _requestCount++;

                    _gotPoints.Add(endPoint);

                    App.UpdateLeaderBoard();
                }


            }



            return null;
        }
    }
}
