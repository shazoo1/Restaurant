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
using Restaurant.Service.Models;
using AutoMapper;
using Restaurant.Service.Models.Order;
using Restaurant.Service.Identity;
using Restaurant.Domain.Identity.Entities;

namespace Restaurant.Service.Service
{
    public class OrderService : BaseService<OrderModel>, IOrderService
    {
        public OrderService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper) { }

        public OrderModel GetById(Guid id)
        {
            var order = _uow.Get<Order>().FindById(id);
            return _mapper.Map<OrderModel>(order);
        }

        public void AddNewOrder(List<OrderPartJsModel> jsOrderParts,
            int tableNumber, IPrincipal user)
        {
            var order = new Order();
            order.CreatedAt = DateTime.Now;
            order.LastModifiedAt = DateTime.Now;
            order.State = OrderState.Accepted;
            order.TableNumber = tableNumber;
            order.Author = user.Identity.Name;
            var dishesRepo = _uow.Get<Dish>();
            decimal price = 0;
            jsOrderParts.ForEach(x =>
            {
                var dish = dishesRepo.FindById(x.Id);
                price += dish.Price * x.Quantity;
                order.OrderParts.Add(new OrderPart
                {
                    Dish = dish,
                    Quantity = x.Quantity,
                });
            });
            order.Price = price;
            var repo =_uow.Get<Order>();
            repo.Add(_mapper.Map<Order>(order));
        }

        public List<OrderModel> GetAll()
        {
            var repo = _uow.Get<Order>();
            var orders = ((IEnumerable<Order>)repo.GetAll()).ToList();
            return _mapper.Map<List<OrderModel>>(orders);
        }

        public List<OrderModel> GetAll(DateTime? filterDate,
            int? filterTableNumber, OrderState? filterState)
        {
            var repo = _uow.Get<Order>();
            var orders = ((IEnumerable<Order>)repo.GetAll()).ToList();
            var result = _mapper.Map<IEnumerable<OrderModel>>(orders);
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
            if (result == null)
                return new List<OrderModel>();
            return result.ToList();
        }

        public IEnumerable<OrderModel> GetAllForUser(IPrincipal user,
            DateTime? filterDate, int? filterTableNumber,
            OrderState? filterState)
        {
            if (user.IsInRole(RoleName.Admin) || user.IsInRole(RoleName.Waiter))
                return GetAll(filterDate, filterTableNumber, filterState);
            if (user.IsInRole(RoleName.Cook))
                return GetAll(filterDate, filterTableNumber, null).Where(x =>
                    x.State == OrderState.Accepted);
            return new List<OrderModel>();
        }

        public void Update(OrderModel orderModel)
        {
            orderModel.LastModifiedAt = DateTime.Now;
            var repo = _uow.Get<Order>();
            repo.Update(_mapper.Map<Order>(orderModel));
        }

        public void UpdateWithDishes(List<OrderPartModel> orderParts, Guid orderId)
        {
            var ordersRepo = _uow.Get<Order>();
            var dishesRepo = _uow.Get<Dish>();
            var order = ordersRepo.GetAllWhere(x => x.Id == orderId)
                .FirstOrDefault();
            decimal orderPartsCost = 0;
            orderParts.ForEach(x =>
            {
                var dish = dishesRepo.FindById(x.Dish.Id);
                x.Dish = _mapper.Map<DishModel>(dish);
                var dbOrderPart = order.OrderParts
                    .Where(y => y.Dish.Id == x.Dish.Id)
                    .FirstOrDefault();
                if (dbOrderPart != null)
                {
                    dbOrderPart.Quantity += x.Quantity;
                }
                else
                {
                    order.OrderParts.Add(new OrderPart {
                        Dish = dish,
                        Quantity = x.Quantity
                    });
                }
                orderPartsCost += x.Dish.Price * x.Quantity;
            });
            order.Price += orderPartsCost;
            ordersRepo.Update(order);
        }
    }
}
