using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ClubGrid.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity, bool commit = true);
        void AddRange(IEnumerable<TEntity> entities, bool commit = true);

        void Remove(TEntity entity, bool commit = true);
        void RemoveRange(IEnumerable<TEntity> entities, bool commit = true);

        void CommitChanges();
    }
}
