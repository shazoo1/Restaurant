using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Service.Interfaces
{
    public interface IOrderService : IBaseService<Order>
    {
        List<Order> GetAll();
        void AddNewOrder(Order order);
        IEnumerable<Order> GetAllForUser(IPrincipal user);
        new void Update(Order order);
        void UpdateWithDishes(List<OrderPart> orderParts, Guid orderId);
    }
}
