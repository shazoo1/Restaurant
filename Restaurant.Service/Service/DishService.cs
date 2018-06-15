using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Service.Interfaces;

namespace Restaurant.Service.Service
{
    public class DishService : BaseService<Dish>, IDishService
    {
        public DishService(IUnitOfWork uow) : base(uow) { }
    }
}
