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
using Restaurant.Domain.Enums;

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
            return ((IEnumerable<Order>)repo.GetAll()).ToList();
        }

        private IEnumerable<Order> GetAllWithStates(OrderState[] states)
        {
            var repo = _uow.Get<Order>();
            return ((IEnumerable<Order>)repo.GetAll()).ToList()
                .Where(x => states.Contains(x.State));
        }

        public IEnumerable<Order> GetAllForUser(IPrincipal user)
        {
            if (user.IsInRole(RoleName.Admin) || user.IsInRole(RoleName.Waiter))
                return GetAll();
            if (user.IsInRole(RoleName.Cook))
                return GetAllWithStates(new OrderState[] { OrderState.accepted });
            return null;
        }
    }
}
