﻿using System;
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

        public List<Dish> GetAllBut(IEnumerable<Guid> ids)
        {
            var repo = _uow.Get<Dish>();
            return ((IEnumerable<Dish>)repo
                .GetAllWhere(x => !ids.Contains(x.Id))).ToList();
        }

        public List<Dish> GetExisting()
        {
            var repo = _uow.Get<Dish>();
            return ((IEnumerable<Dish>)repo.GetAllWhere(x => !x.IsDelete))
                .ToList();
        }

        public void Delete(Guid id)
        {
            var repo = _uow.Get<Dish>();
            var dish = repo.FindById(id);
            dish.IsDelete = true;
            repo.Update(dish);
        }

        public List<Dish> GetDishesByIds(List<Guid> ids)
        {
            var repo = _uow.Get<Dish>();
            return ((IEnumerable<Dish>)repo
                .GetAllWhere(x => ids.Contains(x.Id))).ToList();
        }
    }
}
