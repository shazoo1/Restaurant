using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Service.Interfaces
{
    public interface IBaseService<T> where T : IEntity
    {
        List<T> GetAll();
        T GetById(Guid id);
        void Remove(Guid id);
        void Remove(T item);
        T Add(T item);
        T Update(T item);
    }
}