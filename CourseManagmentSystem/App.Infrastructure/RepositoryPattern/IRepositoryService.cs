using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.RepositoryPattern
{
    public interface IRepositoryService<T>
    { 
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        T Create(T entity);
        T Update(T entity);
        bool Any(Expression<Func<T, bool>> filter);
        void Delete(T entity); 
    }
}
