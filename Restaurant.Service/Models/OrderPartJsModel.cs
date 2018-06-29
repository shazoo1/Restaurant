using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Service.Models.Order
{
    public class OrderPartJsModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}