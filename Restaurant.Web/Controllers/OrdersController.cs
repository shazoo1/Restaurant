using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Service.Interfaces;
using Restaurant.Web.Models.Order;

namespace Restaurant.Web.Controllers
{
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
            //TODO :: Remove when DB is implemented
            var dbdata = _orderService.GetAll();
            var model = new OrdersListModel();
            return View(model);
        }

        public ActionResult Add()
        {
            var model = new OrderDishesModel();
            model.Unselected = _dishService.GetAll();
            return View(model);
        }
    }
}