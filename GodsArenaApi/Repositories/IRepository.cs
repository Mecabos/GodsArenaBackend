using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity GetInclude<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
        IEnumerable<TEntity> GetMultipleInclude<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : class;
        IEnumerable<TEntity> GetAll();
        TEntity FindOneBy(params Expression<Func<TEntity, bool>>[] predicates);
        IEnumerable<TEntity> FindBy(params Expression<Func<TEntity, bool>>[] predicates);
        

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool Save();
    }
}
