using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Interfaces;
using Restaurant.Persistence.Repositories;

namespace Restaurant.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private RestaurantDbContext _context;
        private Dictionary<Type, IRepository> _repositories = new Dictionary<Type, IRepository>();

        public UnitOfWork()
        {
            _context = new RestaurantDbContext();
            _context.Configuration.ProxyCreationEnabled = true;
            _context.Configuration.LazyLoadingEnabled = true;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IRepository<T> Get<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
                return _repositories[typeof(T)] as IRepository<T>;
            var repoType = typeof(BaseRepository<>).MakeGenericType(typeof(T));
            var repo = (IRepository<T>)Activator.CreateInstance(repoType, _context);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        #region IDisposable
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                    }
                }
            }

            _disposed = true;
        }
        #endregion
    }
}
