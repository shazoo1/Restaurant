using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Service.Interfaces;

namespace Restaurant.Service.Models
{
    public class DishModel : IModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
