using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, bool>>[] includeProperties);
        IQueryable<T> GetAllWhere(params Expression<Func<T, bool>>[] predicates);

        T FindById(Guid id);
        void Add(T item);
        void Add(IEnumerable<T> items);
        void Update(T item);
        void Remove(Guid id);
        void Remove(T item);
        void Remove(IEnumerable<T> items);
    }
}
