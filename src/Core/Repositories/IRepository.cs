using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T> where T : class,new()
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool throwException = true);
        T Get(Expression<Func<T, bool>> expression = null, bool throwException = true);
        T Edit(T entity, Action<EntityEntry<T>> rules = null);
        void Remove(T entity);
        T Add(T entity);
        int Save();
    }
}
