using AmarisBlazorLab.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        virtual public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        virtual public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        virtual public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        virtual public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        virtual public TEntity Get(string id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        virtual public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        virtual public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        virtual public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
