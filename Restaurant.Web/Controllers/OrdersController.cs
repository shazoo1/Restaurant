using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;
using Restaurant.Service.Interfaces;
using Restaurant.Web.Models.Menu;
using Restaurant.Web.Models.Order;
using Restaurant.Web.Models.Order.View;

namespace Restaurant.Web.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        private IOrderService _orderService;
        private IDishService _dishService;

        public OrdersController(IOrderService orderService, IDishService dishService)
        {
            _orderService = orderService;
            _dishService = dishService;
        }

        public ActionResult Index()
        {
            var dbdata = _orderService.GetAll();
            var model = new OrderListViewModel();
            model.OrderList = Mapper.Map<List<OrderViewModel>>
                (_orderService.GetAllForUser(User));
            return View(model);
        }

        [Authorize(Roles = RoleName.Admin+","+ RoleName.Waiter)]
        public ActionResult Add()
        {
            var model = new NewOrderViewModel();
            model.Dishes = Mapper.Map<List<DishOrderModel>>(_dishService.GetAll());
            return View(model);
        }

        public ActionResult Create(List<NewOrderModel> order, int tableNumber)
        {
            var newOrder = new Order();
            newOrder.TableNumber = tableNumber;
            var dishesIds = order.Select(x => x.Id).ToList();
            var orderedDishes = _dishService.GetDishesByIds(dishesIds);
            newOrder.Dishes = new List<OrderPart>();
            order.ForEach(x => {
                newOrder.Dishes.Add(new OrderPart {
                    Dish = orderedDishes.Where(z => z.Id == x.Id).First(),
                    Quantity = x.Quantity
                });
            });
            newOrder.Author = User.Identity.Name;
            _orderService.AddNewOrder(newOrder);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Amend(OrderHeaderViewModel orderHeaderViewModel)
        {
            if (orderHeaderViewModel.Id == Guid.Empty)
            {
                return RedirectToAction("Index", "Orders");
            }
            var model = new OrderViewModel();
            model = Mapper.Map<OrderViewModel>(_orderService.GetById(orderHeaderViewModel.Id));
            model.OtherDishes = (Mapper.Map<List<DishMenuModel>>
                (_dishService.GetAll()));
            if (User.IsInRole(RoleName.Cook))
            {
                model.IsCook = true;
            }
            if (User.IsInRole(RoleName.Waiter))
            {
                model.IsWaiter = true;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SetCooked(Guid id)
        {
            UpdateWithState(id, OrderState.ready);
            return RedirectToAction("Index", "Orders");
        }

        [HttpPost]
        public ActionResult SetServed(Guid id)
        {
            UpdateWithState(id, OrderState.served);
            return RedirectToAction("Index", "Orders");
        }

        [HttpPost]
        public ActionResult SetPaid(Guid id)
        {
            UpdateWithState(id, OrderState.paid);
            return RedirectToAction("Index", "Orders");
        }

        private void UpdateWithState(Guid id, OrderState state)
        {
            var order = _orderService.GetById(id);
            order.State = state;
            _orderService.Update(order);
        }
    }
}