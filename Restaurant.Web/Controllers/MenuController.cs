using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;
using Restaurant.Service.Interfaces;
using Restaurant.Web.Models.Menu;

namespace Restaurant.Web.Controllers
{
    [Authorize (Roles = RoleName.Admin)]
    public class MenuController : Controller
    {
        private readonly IDishService _dishService;

        public MenuController(IDishService dishService)
        {
            _dishService = dishService;
        }
        // GET: Menu
        public ActionResult Index()
        {
            var dishesListModel = new DishesListModel();
            dishesListModel.Dishes = Mapper.Map<List<DishMenuModel>>(_dishService.GetAll());
            return View(dishesListModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DishMenuModel dish)
        {
            _dishService.Add(new Dish { Name = dish.Name, Price = dish.Price, Description = dish.Description });
            return Json(Url.Action("Index"));
        }
    }
}