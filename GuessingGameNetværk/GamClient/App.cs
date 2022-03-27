using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface;

namespace GamClient
{
    static class App
    {
        public static Client Client { get; set; }
        public static Listener Listener { get; set; }

        public static TextBox Chat { get; set; }


    }
}
