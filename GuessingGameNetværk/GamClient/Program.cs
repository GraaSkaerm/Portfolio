using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInterface;

namespace GamClient
{
    class Program
    {

        static void Main(string[] args)
        {

            App.Chat = new TextBox(new Rectangle(0, 0, 40, 30), InsertDirection.BottomToTop);
            App.Chat.Print();


            App.Client = new Client(5000);

            App.Client.Write("a0001:");
            int port = int.Parse(App.Client.GetResponse());

            App.Listener = new Listener(port);


            new Thread(App.Listener.AcceptNewClientsLoop).Start();


            while (true)
            {
                string input = Console.ReadLine();

                App.Client.Write($"a0002:{input}");
                App.Client.GetResponse();
            }




        }

    }
}
