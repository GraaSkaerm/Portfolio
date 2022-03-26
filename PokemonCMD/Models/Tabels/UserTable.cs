using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    class UserTable : DataTable, IEntity<User>
    {
        public UserTable(DataBase dataBase, string tableName) : base(dataBase, tableName)
        {
        }

        public IEnumerable<User> GetAllWhere(string where)
        {
            object[][] allValues = dataBase.GetValues(tableName, where);

            for (int i = 0; i < allValues.Length; i++)
            {
                yield return new User(allValues[i]);
            }
        }

        public void Add(User user)
        {
            try
            {
                dataBase.Insert(tableName, $"(null,'{user.Name}','{user.Password}')");
            }
            catch (Exception)
            {

                Console.WriteLine("This username is already taken");
            }
        }

        public void AddRange(IEnumerable<User> users)
        {
            foreach (User user in users)
            {
                Add(user);
            }
        }

        protected override string GetData()
        {
            return $"(id INTEGER PRIMARY KEY, name varchar(50) UNIQUE, password varchar(50))";

        }
        public User Get(string where)
        {
            object[] values = dataBase.GetValue(tableName, where);

            if (values == null)
                return null;

            return new User(values);
        }
        public IEnumerable<User> GetAll()
        {
            object[][] values = dataBase.GetValues(tableName);
            for (int i = 0; i < values.Length; i++)
            {
                yield return new User(values);
            }
        }

        public void Remove(User user)
        {
            dataBase.Delete(tableName, $"id ={user.ID}");
        }

        public void Remove(string where)
        {
            dataBase.Delete(tableName, where);
        }

        public void RemoveRange(IEnumerable<User> users)
        {
            foreach (User user in users)
            {
                Remove(user);
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}

