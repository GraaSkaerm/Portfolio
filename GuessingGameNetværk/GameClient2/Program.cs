using Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInterface;
using GameClient.Receievers;

namespace GameClient
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER SERVER IP:");
            string ip = Console.ReadLine();

            App.Client = new Client(ip, 5000);

            App.Client.Write("a0001");
            int port = int.Parse(App.Client.GetResponse());

            IRequestHandler[] handlers = new IRequestHandler[]
            {
                new HandleRecieveMessageRequest(),
                new HandleRecieveLobbyRequest(),
                new HandleIsGameStartetRequest(),
                new ReceiveQuestion(),
                new ReceiveTime(),
                new ReceiveLeaderBoard(),
                new ReceiveGameIsDone(),
            };

            App.Listener = new Listener(port, handlers);

            Thread thread = new Thread(() => App.Listener.AcceptNewClientsLoop());

            thread.IsBackground = true;
            thread.Start();

            App.Run();
        }


     
        
    }
}
