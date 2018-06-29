using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Service.Interfaces;
using Restaurant.Service.Models;

namespace Restaurant.Service.Service
{
    public class DishService : BaseService<DishModel>, IDishService
    {
        public DishService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper) { }

        public List<DishModel> GetAllBut(IEnumerable<Guid> ids)
        {
            var repo = _uow.Get<Dish>();
            var dishes = ((IEnumerable<Dish>)repo
                .GetAllWhere(x => !ids.Contains(x.Id))).ToList();
            return _mapper.Map<List<DishModel>>(dishes);
        }

        public void Delete(Guid id)
        {
            var repo = _uow.Get<Dish>();
            var dish = repo.FindById(id);
            dish.IsDelete = true;
            repo.Update(dish);
        }

        public List<DishModel> GetDishesByIds(List<Guid> ids)
        {
            var repo = _uow.Get<Dish>();
            var dishes = ((IEnumerable<Dish>)repo
                .GetAllWhere(x => ids.Contains(x.Id))).ToList();
            return _mapper.Map<List<DishModel>>(dishes);
        }

        public List<DishModel> GetAll()
        {
            var repo = _uow.Get<Dish>();
            var dishes = ((IEnumerable<Dish>)repo.GetAllWhere(x => !x.IsDelete))
                .ToList();
            return _mapper.Map<List<DishModel>>(dishes);
        }

        public List<DishModel> GetAbsolutelyAll()
        {
            var repo = _uow.Get<Dish>();
            var dishes = ((IEnumerable<Dish>)repo.GetAll()).ToList();
            return _mapper.Map<List<DishModel>>(dishes);
        }

        public void Add(DishModel dish)
        {
            var repo = _uow.Get<Dish>();
            repo.Add(_mapper.Map<Dish>(dish));
        }
    }
}
