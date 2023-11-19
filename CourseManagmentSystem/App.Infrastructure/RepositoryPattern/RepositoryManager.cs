using App.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.RepositoryPattern
{
    public class RepositoryManager<T> : IRepositoryService<T> where T : class
    {
        private DbSet<T> _dbSet;
        public RepositoryManager(PostreSqlDatabaseContext postreSqlDatabaseContext)
        {
            _dbSet = postreSqlDatabaseContext.Set<T>();
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).SingleOrDefault();
        } 

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            return filter is null ? _dbSet : _dbSet.Where(filter);
        } 
        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
