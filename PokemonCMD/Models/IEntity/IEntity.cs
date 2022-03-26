using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonCMD
{
    interface IEntity<TEntity> where TEntity : class
    {
        TEntity Get(string where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAllWhere(string where);

        void Update(TEntity entity);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity enitty);
        void Remove(string where);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
