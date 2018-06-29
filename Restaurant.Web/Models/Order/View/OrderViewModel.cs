using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Entities;
using Restaurant.Service.Models;
using Restaurant.Web.Models.Menu;

namespace Restaurant.Web.Models.Order.View
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public int TableNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string OrderState { get; set; }
        public string UserName { get; set; }
        public List<OrderDishViewModel> OrderParts { get; set; }
        public bool IsCook { get; set; }
        public bool IsWaiter { get; set; }
        public bool IsAdmin { get; set; }
        public List<DishModel> Dishes { get; set; }

    }
}