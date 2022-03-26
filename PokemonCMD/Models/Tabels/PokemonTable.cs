using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class PokemonTable : DataTable, IEntity<Pokemon>
    {
        public PokemonTable(DataBase database, string tableName) : base(database, tableName)
        {
        }

        public void Add(Pokemon pokemon)
        {
            try
            {
                dataBase.Insert(tableName, $"(null, {pokemon.UserID}, '{pokemon.Name}', {pokemon.Level}, {pokemon.Health}, {pokemon.MaxHealth}, {pokemon.Damage}, {pokemon.Speed})");
            }
            catch (Exception)
            {
                Console.WriteLine($"Pokemon {pokemon.Name} is in the table");
            }
        }

        public void AddRange(IEnumerable<Pokemon> pokemons)
        {
            foreach (Pokemon pokemon in pokemons)
            {
                Add(pokemon);
            }
        }

        public IEnumerable<Pokemon> GetAllWhere(string where)
        {
            object[][] allValues = dataBase.GetValues(tableName, where);

            for (int i = 0; i < allValues.Length; i++)
            {
                yield return new Pokemon(allValues[i]);
            }
        }

        public Pokemon Get(string where)
        {
            object[] values = dataBase.GetValue(tableName, where);

            if (values == null)
                return null;

            return new Pokemon(values);
        }

        public IEnumerable<Pokemon> GetAll()
        {
            object[][] allValues = dataBase.GetValues(tableName);

            for (int i = 0; i < allValues.Length; i++)
            {
                yield return new Pokemon(allValues[i]);
            }
        }

        public void Update(Pokemon pokemon)
        {
            dataBase.Update(tableName, $"level={pokemon.Level}, health={pokemon.Health}, maxHealth={pokemon.MaxHealth}, damage={pokemon.Damage}, speed={pokemon.Speed} WHERE id={pokemon.ID}");
        }

        public void Remove(Pokemon pokemon)
        {
            dataBase.Delete(tableName, $"id={pokemon.ID}");
        }

        public void Remove(string where)
        {
            dataBase.Delete(tableName, where);
        }

        public void RemoveRange(IEnumerable<Pokemon> pokemons)
        {
            foreach (Pokemon pokemon in pokemons)
            {
                Remove(pokemon);
            }
        }

        protected override string GetData()
        {
            return $"(id INTEGER PRIMARY KEY, userID INTEGER REFERENCES Users(id), name VARCHAR(50), level INTEGER, health INTEGER, maxHealth INTEGER, damage INTEGER, speed INTEGER)";
        }
    }
}
