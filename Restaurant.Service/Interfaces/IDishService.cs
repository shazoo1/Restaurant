using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Service.Models;

namespace Restaurant.Service.Interfaces
{
    public interface IDishService : IBaseService<DishModel>
    {
        List<DishModel> GetAll();
        List<DishModel> GetDishesByIds(List<Guid> ids);
        List<DishModel> GetAllBut(IEnumerable<Guid> ids);
        List<DishModel> GetAbsolutelyAll();
        void Delete(Guid id);
        void Add(DishModel dish);
    }
}
