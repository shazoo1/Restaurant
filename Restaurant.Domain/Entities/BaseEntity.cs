using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDelete { get; set; }
    }
}
