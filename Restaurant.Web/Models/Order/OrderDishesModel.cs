using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Entities;

namespace Restaurant.Web.Models.Order
{
    public class OrderDishesModel
    {
        public List<Dish> Unselected { get; set; } = new List<Dish>();
        public List<Dish> Selected { get; set; } = new List<Dish>();
    }
}