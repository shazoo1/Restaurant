using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;
using Restaurant.Service.Interfaces;
using Restaurant.Service.Models;
using Restaurant.Service.Models.Order;
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

        public OrdersController(IOrderService orderService, IDishService dishService,
            IMapper mapper) : base(mapper)
        {
            _orderService = orderService;
            _dishService = dishService;
        }

        public ActionResult Index(DateTime? filterDate,
            int? filterTableNumber, OrderState? filterState)
        {
            var model = SetModelRoles(new OrderListViewModel());
            model.OrderList = _mapper.Map<List<OrderViewModel>>
                (_orderService.GetAllForUser(User, filterDate,
                filterTableNumber, filterState));
            return View(model);
        }

        [Authorize(Roles = RoleName.Admin+","+ RoleName.Waiter)]
        public ActionResult Add()
        {
            var model = new NewOrderViewModel();
            model.AllDishes = _mapper.Map<List<DishModel>>(_dishService.GetAll());
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.Admin + "," + RoleName.Waiter)]
        public ActionResult Add(List<OrderPartJsModel> order,
            int tableNumber)
        {
            _orderService.AddNewOrder(order, tableNumber, HttpContext.User);

            return Json(Url.Action("Index", "Orders"));
        }
        
        public ActionResult Details(Guid id)
        {
            var model = _mapper.Map<OrderViewModel>
                (_orderService.GetById(id));
            model.Dishes = _dishService.GetAll();

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
            UpdateWithState(id, OrderState.Ready);
            return RedirectToAction("Index", "Orders");
        }

        [HttpPost]
        public ActionResult SetServed(Guid id)
        {
            UpdateWithState(id, OrderState.Served);
            return RedirectToAction("Index", "Orders");
        }

        [HttpPost]
        public ActionResult SetPaid(Guid id)
        {
            UpdateWithState(id, OrderState.Paid);
            return RedirectToAction("Index", "Orders");
        }
        [HttpPost]
        public ActionResult Change(List<OrderPartModel> dishes, Guid orderId)
        {
            _orderService.UpdateWithDishes(_mapper.Map<List<OrderPartModel>>(dishes),
                orderId);
            return Json(Url.Action("Details", "Orders", new { id = orderId}));
        }

        private void UpdateWithState(Guid id, OrderState state)
        {
            var order = _orderService.GetById(id);
            order.State = state;
            _orderService.Update(order);
        }

        private OrderListViewModel SetModelRoles(OrderListViewModel model)
        {
            if (User.IsInRole(RoleName.Cook))
            {
                model.IsCook = true;
            }
            if (User.IsInRole(RoleName.Waiter))
            {
                model.IsWaiter = true;
            }
            if (User.IsInRole(RoleName.Admin))
            {
                model.IsAdmin = true;
            }
            return model;
        }
    }
}