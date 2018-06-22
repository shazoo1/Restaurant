﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Service.Interfaces
{
    public interface IDishService : IBaseService<Dish>
    {
        List<Dish> GetDishesByIds(List<Guid> ids);
        List<Dish> GetAllBut(IEnumerable<Guid> ids);
    }
}
