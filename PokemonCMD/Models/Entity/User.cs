using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public User(object[] values)
        {
            this.ID = int.Parse(values[0].ToString());
            this.Name = values[1].ToString();
            this.Password = values[2].ToString();
        }

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public User(int Id, string name, string password)
        {
            this.ID = Id;
            this.Name = name;
            this.Password = password;
        }

    }
}
