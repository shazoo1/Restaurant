using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;
using Restaurant.Service.Models;
using Restaurant.Service.Models.Order;

namespace Restaurant.Service.Interfaces
{
    public interface IOrderService : IBaseService<OrderModel>
    {
        OrderModel GetById(Guid id);
        List<OrderModel> GetAll(DateTime? filterDate, int? filterTableNumber, OrderState? filterState);
        void AddNewOrder(List<OrderPartJsModel>newOrderModels,
            int tableNumber, IPrincipal user);
        IEnumerable<OrderModel> GetAllForUser(IPrincipal user,
            DateTime? filterDate, int? filterTableNumber,
            OrderState? filterState);
        void Update(OrderModel orderModel);
        void UpdateWithDishes(List<OrderPartModel> orderPartModels, Guid orderId);
    }
}
