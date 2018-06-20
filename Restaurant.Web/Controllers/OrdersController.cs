using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Service.Interfaces;
using Restaurant.Web.Models.Menu;
using Restaurant.Web.Models.Order;

namespace Restaurant.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller
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
            var model = new OrdersListModel();
            model.OrdersList = Mapper.Map<List<OrderModel>>(_orderService.GetAll());
            return View(model);
        }

        public ActionResult Add()
        {
            var model = new OrderDishesModel();
            model.Unselected = _dishService.GetAll();
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
            _orderService.AddNewOrder(newOrder);
            return new RedirectResult("/Orders/Index");
        }
    }
}