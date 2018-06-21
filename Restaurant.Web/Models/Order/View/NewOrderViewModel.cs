using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Entities;

namespace Restaurant.Web.Models.Order.View
{
    public class NewOrderViewModel
    {
        public List<DishOrderModel> Dishes { get; set; } = new List<DishOrderModel>();
    }
}