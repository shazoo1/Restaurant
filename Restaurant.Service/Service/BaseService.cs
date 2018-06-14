using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Service.Interfaces;

namespace Restaurant.Service.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _uow;
        protected BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public T Add(T item)
        {
            _uow.Get<T>().Add(item);
            _uow.SaveChanges();
            return item;
        }

        public T GetById(Guid id)
        {
            return _uow.Get<T>().FindById(id);
        }

        public virtual void Remove(Guid id)
        {
            _uow.Get<T>().Remove(id);
            _uow.SaveChanges();
        }

        public virtual void Remove(T item)
        {
            _uow.Get<T>().Remove(item);
            _uow.SaveChanges();
        }

        public T Update(T item)
        {
            _uow.Get<T>().Update(item);
            _uow.SaveChanges();
            return item;
        }
    }
}
