using Core.Exceptions;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public abstract class Repository<T> : IRepository<T>
        where T : class, new()
    {
        private readonly DbContext db;
        private readonly DbSet<T> _table;
        protected Repository(DbContext db)
        {
            this.db = db;
            _table = db.Set<T>();
        }
        protected DbContext Db { get => db; }
        protected DbSet<T> Table { get => _table; }
        public T Add(T entity)
        {
            _table.Add(entity);
            return entity;
        }

        public T Edit(T entity, Action<EntityEntry<T>> rules = null)
        {
            var entry = db.Entry<T>(entity);

            if (rules == null)
                goto summary;

            foreach (var item in typeof(T).GetProperties().Where(m => m.IsEditable()))
            {
                entry.Property(item.Name).IsModified= false;
            }

            rules(entry);

            summary:
            entry.State = EntityState.Modified;

            return entity;
        }

        public T Get(Expression<Func<T, bool>> expression = null, bool throwException = true)
        {

            //return _table.FirstOrDefault(expression??) ?? throw new NotFoundException();
 
            var query = _table.AsQueryable();

            if (expression != null)
                query = query.Where(expression);

            var entity = query.FirstOrDefault();

            if (entity == null && throwException)
                throw new NotFoundException($"{typeof(T).Name}: Qeyd tapılmadı");

            return entity;

        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null,bool throwException =true)
        {
            if (expression!=null)
            {
                return _table.Where(expression).AsQueryable(); 
            }
            return _table.AsQueryable();
            
        }

        public void Remove(T entity)
        {
            _table.Remove(entity);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
