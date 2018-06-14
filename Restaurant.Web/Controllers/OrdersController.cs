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
        private OrdersListModel _model;
        private IOrderService _orderService;
        
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            //TODO :: Remove when DB is implemented
            var dbdata = _orderService.GetAll();
            _model = new OrdersListModel();
            return View(_model);
        }
    }
}