using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.RequestHandlers;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {

            IRequestHandler[] requestHandlers = new IRequestHandler[]
            {
                new HandleGetPortRequest(),
                new HandleSendMessageRequest(),
                new HandleIsNameTakenRequest(),
                new HandleUpdateLobbyRequest(),
                new HandleIsEveryoneReadyRequest(),
                new HandleStartGameRquest(),
                new HandleIsGameStartetRequest(),
                new HandleIsAnswerCorrectRequest(),
                new HandleGetPointsRequest(),
            };

            App.Listener = new Listener(5000, requestHandlers);

            App.Listener.IsDebuging = true;

            App.Listener.AcceptNewClientsLoop();



        }
    }
}
