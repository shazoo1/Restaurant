using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Service.Interfaces;
using Microsoft.AspNet.Identity;
using System.Security.Principal;

namespace Restaurant.Service.Service
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        public OrderService(IUnitOfWork uow) : base(uow) { }

        public void AddNewOrder(Order order)
        {
            order.CreatedAt = DateTime.Now;
            order.LastModifiedAt = DateTime.Now;
            order.State = Domain.Enums.OrderState.accepted;
            var repo =_uow.Get<Order>();
            repo.Add(order);
        }

        public new List<Order> GetAll()
        {
            var repo = _uow.Get<Order>();
            return repo.GetAllIncluding(x => { return x.Dishes});
        }
    }
}
