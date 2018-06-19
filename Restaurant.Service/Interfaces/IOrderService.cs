using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Service.Interfaces
{
    public interface IOrderService : IBaseService<Order>
    {
        List<Order> GetAll();
        void AddNewOrder(Order order);
    }
}
