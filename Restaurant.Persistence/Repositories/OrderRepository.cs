using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(DbContext context) : base(context) { }

        public new void Update(Order order)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(order);
            order.OrderParts.ForEach(x =>
            {
                DbEntityEntry dishEntry = Context.Entry(x.Dish);
                dishEntry.State = EntityState.Unchanged;
            });
            if (dbEntityEntry.State == EntityState.Detached)
                DbSet.Attach(order);
            dbEntityEntry.State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
