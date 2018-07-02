using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Service.Models;
using Restaurant.Web.Models.Menu;
using Restaurant.Web.Models.Menu.View;
using Restaurant.Web.Models.Order;
using Restaurant.Web.Models.Order.View;
using Restaurant.Web.Models.Users;

namespace Restaurant.Web.Mapping
{
    public class WebProfile : Profile
    {
        public class ModelToViewModel : Profile
        {
            public ModelToViewModel()
            {
                CreateMap<OrderModel, OrderViewModel>()
                    .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Author))
                    .ForMember(d => d.OrderState, opt => opt.MapFrom(s => s.State));
                CreateMap<OrderPartModel, OrderPartViewModel>()
                    .ForMember(d => d.Dish, opt => opt.ResolveUsing((s, d, i, context) => {
                        return context.Mapper.Map<DishModel>(s.Dish);
                    }))
                    .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Quantity))
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
            }
        }

        public class ViewModelToModel : Profile
        {
            public ViewModelToModel()
            {
                CreateMap<NewDishViewModel, DishModel>();
                CreateMap<UserViewModel, UserModel>();
            }
        }
    }
}