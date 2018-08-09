using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GodsArenaApi.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity GetInclude<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            var query = Context.Set<TEntity>().AsQueryable();
            if (includes != null)
                if (includes.Length > 0)
                    foreach (var include in includes)
                        query = query.Include(include);
            return query.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetMultipleInclude<TEntity>(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            var query = Context.Set<TEntity>().AsQueryable();
            if (includes != null)
                if (includes.Length > 0)
                    foreach (var include in includes)
                        query = query.Include(include);
            return query.Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity FindOneBy(params Expression<Func<TEntity, bool>>[] predicates)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            if (predicates != null)
                if (predicates.Length > 0)
                    foreach (var predicate in predicates)
                        query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> FindBy(params Expression<Func<TEntity, bool>>[] predicates)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            if (predicates != null)
                if (predicates.Length > 0)
                    foreach (var predicate in predicates)
                        query = query.Where(predicate);
            return query;
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public bool Save()
        {
            return (Context.SaveChanges() >= 0);
        }

    }
}
