using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Entities;
using Restaurant.Service.Models;

namespace Restaurant.Web.Models.Order.View
{
    public class NewOrderViewModel
    {
        public List<DishModel> AllDishes { get; set; } = new List<DishModel>();
    }
}