using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonCMD
{
    class PokedexTable : DataTable, IEntity<PokedexPokemon>
    {

        public PokedexTable(DataBase dataBase, string tableName) : base(dataBase, tableName)
        {
            if (GetAll().ToArray().Length == 0)
                FillTable();
        }

        private void FillTable()
        {
            Console.WriteLine("\n\n\n");
            TextPrinter.Print("Loading pokemons...");

            dataBase.Insert(tableName, "(null, 'bulbasaur')");
            dataBase.Insert(tableName, "(null, 'ivysaur')");
            dataBase.Insert(tableName, "(null, 'venusaur')");
            dataBase.Insert(tableName, "(null, 'charmander')");
            dataBase.Insert(tableName, "(null, 'charmeleon')");
            dataBase.Insert(tableName, "(null, 'charizard')");
            dataBase.Insert(tableName, "(null, 'squirtle')");
            dataBase.Insert(tableName, "(null, 'wartortle')");
            dataBase.Insert(tableName, "(null, 'blastoise')");
            dataBase.Insert(tableName, "(null, 'caterpie')");
            dataBase.Insert(tableName, "(null, 'metapod')");
            dataBase.Insert(tableName, "(null, 'butterfree')");
            dataBase.Insert(tableName, "(null, 'beedrill')");
            dataBase.Insert(tableName, "(null, 'pidgey')");
            dataBase.Insert(tableName, "(null, 'pidgeotto')");
            dataBase.Insert(tableName, "(null, 'pidgeot')");
            dataBase.Insert(tableName, "(null, 'rattata')");
            dataBase.Insert(tableName, "(null, 'raticate')");
            dataBase.Insert(tableName, "(null, 'spearow')");
            dataBase.Insert(tableName, "(null, 'fearow')");
            dataBase.Insert(tableName, "(null, 'ekans')");
            dataBase.Insert(tableName, "(null, 'arbok')");
            dataBase.Insert(tableName, "(null, 'pikachu')");
            dataBase.Insert(tableName, "(null, 'raichu')");
            dataBase.Insert(tableName, "(null, 'sandshrew')");
            dataBase.Insert(tableName, "(null, 'sandslash')");
            dataBase.Insert(tableName, "(null, 'clefairy')");
            dataBase.Insert(tableName, "(null, 'clefable')");
            dataBase.Insert(tableName, "(null, 'vulpix')");
            dataBase.Insert(tableName, "(null, 'ninetales')");
            dataBase.Insert(tableName, "(null, 'jigglypuff')");
            dataBase.Insert(tableName, "(null, 'wigglytuff')");
            dataBase.Insert(tableName, "(null, 'zubat')");
            dataBase.Insert(tableName, "(null, 'golbat')");
            dataBase.Insert(tableName, "(null, 'meowth')");
            dataBase.Insert(tableName, "(null, 'persian')");
            dataBase.Insert(tableName, "(null, 'psyduck')");
            dataBase.Insert(tableName, "(null, 'golduck')");
            dataBase.Insert(tableName, "(null, 'mankey')");
            dataBase.Insert(tableName, "(null, 'primeape')");
            dataBase.Insert(tableName, "(null, 'kadabra')");
            dataBase.Insert(tableName, "(null, 'alakazam')");
            dataBase.Insert(tableName, "(null, 'machop')");
            dataBase.Insert(tableName, "(null, 'machoke')");
            dataBase.Insert(tableName, "(null, 'machamp')");
            dataBase.Insert(tableName, "(null, 'geodude')");
            dataBase.Insert(tableName, "(null, 'rapidash')");
            dataBase.Insert(tableName, "(null, 'slowpoke')");
            dataBase.Insert(tableName, "(null, 'slowbro')");
            dataBase.Insert(tableName, "(null, 'seel')");
            dataBase.Insert(tableName, "(null, 'dewgong')");
            dataBase.Insert(tableName, "(null, 'grimer')");
            dataBase.Insert(tableName, "(null, 'muk')");
            dataBase.Insert(tableName, "(null, 'onix')");
            dataBase.Insert(tableName, "(null, 'krabby')");
            dataBase.Insert(tableName, "(null, 'kingler')");
            dataBase.Insert(tableName, "(null, 'voltorb')");
        }

        protected override string GetData()
        {
            return $"(id INTEGER PRIMARY KEY, name VARCHAR(50) UNIQUE)";
        }

        public PokedexPokemon Get(string where)
        {
            object[] values = dataBase.GetValue(tableName, where);
            
            if (values == null)
                return null;

            return new PokedexPokemon(values);
        }

        public PokedexPokemon GetPokemon(string name)
        {
            object[] values = dataBase.GetValue(tableName, $"name='{name}'");
            return new PokedexPokemon(values);
        }

        public IEnumerable<PokedexPokemon> GetAll()
        {
            object[][] allValues = dataBase.GetValues(tableName);

            for (int i = 0; i < allValues.Length; i++)
            {
                yield return new PokedexPokemon(allValues[i]);
            }
        }

        public IEnumerable<PokedexPokemon> GetAllWhere(string where)
        {
            object[][] allValues = dataBase.GetValues(tableName, where);

            for (int i = 0; i < allValues.Length; i++)
            {
                yield return new PokedexPokemon(allValues[i]);
            }
        }

        public void Add(PokedexPokemon pokdexPokemon)
        {
            try
            {
                dataBase.Insert(tableName, $"(null, '{pokdexPokemon.Name}')");
            }
            catch (Exception)
            {
                Console.WriteLine($"{pokdexPokemon.Name} is in the table");
            }
        }

        public void AddRange(IEnumerable<PokedexPokemon> pokedexPokemons)
        {
            foreach (PokedexPokemon pokdexPokemon in pokedexPokemons)
            {
                Add(pokdexPokemon);
            }
        }

        public void Remove(PokedexPokemon pokdexPokemon)
        {
            dataBase.Delete(tableName, $"id={pokdexPokemon.ID}");
        }

        public void RemoveRange(IEnumerable<PokedexPokemon> pokedexPokemons)
        {
            foreach (PokedexPokemon pokdexPokemon in pokedexPokemons)
            {
                Remove(pokdexPokemon);
            }
        }

        public void Remove(string where)
        {
            dataBase.Delete(tableName, where);
        }

        public void Update(PokedexPokemon entity)
        {
            throw new NotImplementedException();
        }
    }
}
