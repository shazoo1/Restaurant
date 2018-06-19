using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Web.Models.Menu
{
    public class NewOrderModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}