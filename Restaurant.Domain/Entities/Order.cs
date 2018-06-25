using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int TableNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public virtual List<OrderPart> OrderParts { get; set; }
        public OrderState State { get; set; }
        public string Author { get; set; }

    }
}
