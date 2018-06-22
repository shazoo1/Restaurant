using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Entities;
using Restaurant.Web.Models.Menu;

namespace Restaurant.Web.Models.Order.View
{
    public class OrderViewModel
    {
        public OrderHeaderViewModel OrderHeader { get; set; }
        public List<OrderDishViewModel> Dishes { get; set; }
        public List<DishMenuModel> OtherDishes { get; set; }
        public bool IsCook { get; set; }
        public bool IsWaiter { get; set; }
        public bool IsAdmin { get; set; }
    }
}