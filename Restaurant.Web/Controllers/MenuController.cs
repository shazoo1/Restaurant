using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;
using Restaurant.Service.Interfaces;
using Restaurant.Service.Models;
using Restaurant.Web.Models.Menu;
using Restaurant.Web.Models.Menu.View;

namespace Restaurant.Web.Controllers
{
    [Authorize (Roles = RoleName.Admin)]
    public class MenuController : BaseController
    {
        private readonly IDishService _dishService;

        public MenuController(IDishService dishService, IMapper mapper) : base (mapper)
        {
            _dishService = dishService;
        }
        // GET: Menu
        public ActionResult Index()
        {
            var dishesListModel = new DishesListViewModel();
            dishesListModel.Dishes = _dishService.GetAll();
            return View(dishesListModel);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewDishViewModel dish)
        {
            _dishService.Add(_mapper.Map<DishModel>(dish));
            return RedirectToAction("Index", "Menu");
        }
        
        public ActionResult Delete(Guid id)
        {
            _dishService.Delete(id);
            return RedirectToAction("Index", "Menu");
        }
    }
}