﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Web.Models.Order
{
    public class DishOrderModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}