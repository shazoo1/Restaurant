using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Service.Models;

namespace Restaurant.Web.Models.Order.View
{
    public class OrderPartViewModel
    {
        public Guid Id { get; set; }
        public DishModel Dish { get; set; }
        public int Quantity { get; set; }
    }
}