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
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IUnitOfWork uow) : base(uow) { }

        public List<Order> GetAll()
        {
            return ((IEnumerable<Order>)(_uow.Get<Order>().GetAll())).ToList<Order>();
        }
    }
}
