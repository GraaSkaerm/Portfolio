using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    abstract class DataTable
    {
        protected DataBase dataBase;
        protected string tableName;

        public DataTable(DataBase dataBase, string tableName)
        {
            this.dataBase = dataBase;
            this.tableName = tableName;
            dataBase.CreateTable(tableName, GetData());
        }

        protected abstract string GetData();
    }
}
