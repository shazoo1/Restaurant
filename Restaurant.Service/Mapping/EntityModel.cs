using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Service.Models;

namespace Restaurant.Service.Mapping
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<Dish, DishModel>();
            CreateMap<Order, OrderModel>()
                .ForMember(d => d.OrderParts,
                opt => opt.MapFrom<IEnumerable<OrderPart>>(s => s.OrderParts));
            CreateMap<OrderPart, OrderPartModel>();
        }
    }

    public class ModelToEntity : Profile
    {
        public ModelToEntity()
        {
            CreateMap<DishModel, Dish>();
            CreateMap<OrderModel, Order>();
            CreateMap<OrderPartModel, OrderPart>();
        }
    }
}
