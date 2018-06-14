using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Identity.Entities;

namespace Restaurant.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int TableNumber { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
        public OrderState State { get; set; }
        public User Author { get; set; }

    }
}
