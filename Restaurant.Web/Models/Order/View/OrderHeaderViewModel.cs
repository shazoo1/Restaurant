﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Web.Models.Order.View
{
    public class OrderHeaderViewModel
    {
        public Guid Id { get; set; }
        public int TableNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string OrderState { get; set; }
        public string UserName { get; set; }
    }
}