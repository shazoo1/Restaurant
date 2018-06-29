using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Enums;
using Restaurant.Service.Interfaces;

namespace Restaurant.Service.Models
{
    public class OrderModel : IModel
    {
        public Guid Id { get; set; }
        public int TableNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public OrderState State { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<OrderPartModel> OrderParts { get; set; }
    }
}