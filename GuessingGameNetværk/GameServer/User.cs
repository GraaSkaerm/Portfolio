using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class User
    {
        public string Name { get; set; }
        public bool IsReady { get; set; }
        public int Score { get; set; }


        public override string ToString()
        {
            string s = IsReady ? "Ready" : "Not ready";

            return $"{Name}: {s}";
        }

    }
}
