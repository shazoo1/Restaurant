using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Domain.Enums;

namespace Restaurant.Web.Models.Order.View
{
    public class OrderListViewModel
    {
        public List<OrderViewModel> OrderList { get; set; }
        public int? FilterTableNumber { get; set; }
        public DateTime? FilterDate { get; set; }
        public OrderState? FilterState { get; set; }
        public bool IsWaiter { get; set; }
        public bool IsCook { get; set; }
        public bool IsAdmin { get; set; }
    }
}