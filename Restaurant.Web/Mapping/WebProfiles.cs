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
        public WebProfile()
        {
            CreateMap<Dish, DishMenuModel>();
            CreateMap<DishMenuModel, Dish>();
            CreateMap<OrderPart, OrderDishViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Dish.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Dish.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Dish.Price))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Quantity));
            
            CreateMap<Order, OrderHeaderViewModel>()
                .ForMember(d => d.OrderState, opt => opt.MapFrom(s => s.State))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Author));
            CreateMap<OrderViewModel, Order>();
            CreateMap<UserViewModel, User>();
            CreateMap<(User user, Role role), UserViewModel>()
                .ForMember(d => d.Role, opt => opt.MapFrom(s => s.role.Name))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.user.UserName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.user.Email));
            CreateMap<NewDishViewModel, Dish>();
            
        }
        public class ModelToViewModel : Profile
        {
            public ModelToViewModel()
            {
                CreateMap<OrderModel, OrderViewModel>()
                    .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Author))
                    .ForMember(d => d.OrderState, opt => opt.MapFrom(s => s.State));
                CreateMap<OrderPartModel, OrderDishViewModel>()
                    .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Dish.Name))
                    .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Dish.Name))
                    .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Dish.Price));
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