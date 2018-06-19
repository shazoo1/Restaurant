using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class OrderPart : BaseEntity
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}
