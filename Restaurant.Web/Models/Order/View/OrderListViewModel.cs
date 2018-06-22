using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Web.Models.Order.View
{
    public class OrderListViewModel
    {
        public List<OrderViewModel> OrderList { get; set; }
        public bool IsWaiter { get; set; }
        public bool IsCook { get; set; }
        public bool IsAdmin { get; set; }
    }
}