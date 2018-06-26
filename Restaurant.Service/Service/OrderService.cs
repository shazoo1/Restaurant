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
using Restaurant.Persistence.Repositories;

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

        public List<Order> GetAll(DateTime? filterDate,
            int? filterTableNumber, OrderState? filterState)
        {
            var repo = _uow.Get<Order>();
            var result = ((IEnumerable<Order>)repo.GetAll());
            if (filterDate != null)
            {
                var date = (DateTime)filterDate;
                result = result
                    .Where(x => DateTime.Compare(x.CreatedAt.Date, date.Date) == 0);
            }
            if (filterTableNumber != null)
                result = result.Where(x => x.TableNumber == filterTableNumber);
            if (filterState != null)
                result = result.Where(x => x.State == filterState);
            return result.ToList();
        }

        public IEnumerable<Order> GetAllForUser(IPrincipal user,
            DateTime? filterDate, int? filterTableNumber,
            OrderState? filterState)
        {
            if (user.IsInRole(RoleName.Admin) || user.IsInRole(RoleName.Waiter))
                return GetAll(filterDate, filterTableNumber, filterState);
            if (user.IsInRole(RoleName.Cook))
                return GetAll(filterDate, filterTableNumber, null).Where(x => x.State == OrderState.accepted);
            return null;
        }

        public new void Update(Order order)
        {
            order.LastModifiedAt = DateTime.Now;
            var repo = _uow.Get<Order>();
            repo.Update(order);
        }

        public void UpdateWithDishes(List<OrderPart> orderParts, Guid orderId)
        {
            var ordersRepo = _uow.Get<Order>();
            var dishesRepo = _uow.Get<Dish>();
            var order = ordersRepo.GetAllWhere(x => x.Id == orderId)
                .FirstOrDefault();
            orderParts.ForEach(x =>
            {
                x.Dish = dishesRepo.FindById(x.Dish.Id);
                var dbOrderPart = order.OrderParts
                    .Where(y => y.Dish.Id == x.Dish.Id)
                    .FirstOrDefault();
                if (dbOrderPart != null)
                {
                    dbOrderPart.Quantity += x.Quantity;
                }
                else
                {
                    order.OrderParts.Add(x);
                }
            });
            ordersRepo.Update(order);
        }
    }
}
