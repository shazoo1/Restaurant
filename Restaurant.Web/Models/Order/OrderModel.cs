using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Entities;

namespace Restaurant.Web.Models.Order
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TableNumber { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string OrderState { get; set; }
        public string UserName { get; set; }
        public List<OrderPart> Dishes { get; set; }
    }
}