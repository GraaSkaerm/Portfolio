using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class PokedexPokemon
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public PokedexPokemon(object[] values)
        {
            this.ID = int.Parse(values[0].ToString());
            this.Name = values[1].ToString();
        }

        public PokedexPokemon(string name)
        {
            this.Name = name;
        }

        public PokedexPokemon(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
