using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IRestarauntDbContext : IDisposable
    {
        DbContext DbContext { get; }
    }
}
