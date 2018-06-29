using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Service.Interfaces;

namespace Restaurant.Service.Models
{
    public class OrderPartModel : IModel
    {
        public Guid Id { get; set; }
        public DishModel Dish { get; set; }
        public OrderModel Order { get; set; }
        public int Quantity { get; set; }
    }
}
