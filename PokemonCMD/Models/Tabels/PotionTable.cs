using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class PotionTable : DataTable, IEntity<Potion>
    {

        public PotionTable(DataBase dataBase, string tableName) : base(dataBase, tableName)
        {

        }

        protected override string GetData()
        {
            return $"(id INTEGER PRIMARY KEY, userid INTEGER, type STRING, amount INTEGER)";
        }

        public Potion Get(string where)
        {
            object[] values = dataBase.GetValue(tableName, where);

            if (values == null)
                return null;

            return new Potion(values);
        }

        public Potion GetPotion(string name)
        {
            object[] values = dataBase.GetValue(tableName, $"name='{name}'");
            return new Potion(values);
        }

        public IEnumerable<Potion> GetAll()
        {
            object[][] allValues = dataBase.GetValues(tableName);

            for (int i = 0; i < allValues.Length; i++)
            {
                yield return new Potion(allValues[i]);
            }
        }

        public IEnumerable<Potion> GetAllWhere(string where)
        {
            object[][] allValues = dataBase.GetValues(tableName, where);

            for (int i = 0; i < allValues.Length; i++)
            {
                yield return new Potion(allValues[i]);
            }
        }

        public void Add(Potion potionModel)
        {
            try
            {
                dataBase.Insert(tableName, $"(null, {potionModel.UserID}, '{potionModel.Type}', {potionModel.Amount})");
            }
            catch (Exception)
            {
                Console.WriteLine($"{potionModel.Type} is in the table");
            }
        }

        public void AddRange(IEnumerable<Potion> potionModels)
        {
            foreach (Potion potionModel in potionModels)
            {
                Add(potionModel);
            }
        }

        public void Update(Potion potion)
        {
            dataBase.Update(tableName, $"amount={potion.Amount} WHERE userid={potion.UserID} AND type='{potion.Type}'");
        }

        public void Remove(Potion potionModel)
        {
            dataBase.Delete(tableName, $"id={potionModel.ID}");
        }

        public void RemoveRange(IEnumerable<Potion> potionModels)
        {
            foreach (Potion potionModel in potionModels)
            {
                Remove(potionModel);
            }
        }

        public void Remove(string where)
        {
            dataBase.Delete(tableName, where);
        }



    }
}
