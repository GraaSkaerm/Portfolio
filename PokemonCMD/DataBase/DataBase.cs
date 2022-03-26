using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace PokemonCMD
{
    class DataBase
    {
        private readonly SQLiteConnection path;

        public DataBase(string name)
        {
            this.path = new SQLiteConnection($"Data Source={name}.db; Version=3; New=True;");
        }

        private void Execute(string command)
        {
            path.Open();
            try
            {
                SQLiteCommand c = new SQLiteCommand(command, path);
                c.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //Console.WriteLine("Failed to execute command.");
            }
            path.Close();
        }

        private object[][] ExecuteReader(string command)
        {
            path.Open();
            SQLiteCommand c = new SQLiteCommand(command, path);
            SQLiteDataReader data = c.ExecuteReader();

            List<object[]> values = new List<object[]>();

            while (data.Read())
            {
                Object[] rowValues = new Object[data.FieldCount];
                data.GetValues(rowValues);
                values.Add(rowValues);
            }

            path.Close();


            return values.ToArray();
        }

        public void CreateTable(string tableName, string data)
        {
            Execute($"CREATE TABLE IF NOT EXISTS {tableName} {data}");
        }

        public void DropTable(string tableName)
        {
            Execute($"DROP TABLE {tableName}");
        }

        public void Insert(string tableName, string values)
        {
            Execute($"INSERT INTO {tableName} VALUES {values}");
        }

        public void Update(string tableName, string values)
        {
            Execute($"UPDATE {tableName} SET {values}");
        }

        public void Delete(string tableName, string where)
        {
            Execute($"DELETE FROM {tableName} WHERE {where}");
        }

        public object[][] GetValues(string tableName)
        {
            return ExecuteReader($"SELECT * FROM {tableName}");
        }

        public object[][] GetValues(string tableName, string where)
        {
            return ExecuteReader($"SELECT * FROM {tableName} WHERE {where}");
        }

        public object[] GetValue(string tableName, string where)
        {
            object[][] values = ExecuteReader($"SELECT * FROM {tableName} WHERE {where}");
            if (values.Length > 0)
                return values[0];
            else
                return null;
        }



    }
}
