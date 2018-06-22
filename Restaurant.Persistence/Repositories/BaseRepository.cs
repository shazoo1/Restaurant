using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T: class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public void Add(T item)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(item);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(item);
            }
            Context.SaveChanges();
        }

        public void Add(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public T FindById(Guid id)
        {
            var entity = DbSet.Find(id);
            if (entity != null) return entity;
            return null;
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, bool>>[] includeProperties)
        {
            IQueryable<T> query = GetAll();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<T> GetAllWhere(params Expression<Func<T, bool>>[] predicates)
        {
            IQueryable<T> query = GetAll();
            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(item);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(item);
            }
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
