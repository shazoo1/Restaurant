using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Domain.Entities
{
    public class OrderPart : BaseEntity
    {
        public virtual Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}
