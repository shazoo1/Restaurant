﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Entities;

namespace Restaurant.Web.Models.Order.View
{
    public class OrderViewModel
    {
        public OrderHeaderViewModel OrderHeader { get; set; }
        public List<OrderDishViewModel> Dishes { get; set; }
    }
}