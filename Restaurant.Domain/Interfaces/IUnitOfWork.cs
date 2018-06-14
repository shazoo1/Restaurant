using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Get<T>() where T : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
