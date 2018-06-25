using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Web.Models.Order;

namespace Restaurant.Web.Models.Menu
{
    public class NewOrderModel
    {
        public DishOrderModel Dish { get; set; }
        public int Quantity { get; set; }
    }
}