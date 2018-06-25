using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Identity.Entities;
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
            CreateMap<Dish, DishOrderModel>();
            CreateMap<DishOrderModel, Dish>();
            CreateMap<OrderPart, OrderDishViewModel>()
                .ForMember(d => d.DishId, opt => opt.MapFrom(s => s.Dish.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Dish.Name))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Dish.Price))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Quantity));
            CreateMap<Order, OrderViewModel>()
                 .ForMember(d => d.OrderHeader, opt => opt.ResolveUsing((Mapper.Map<Order>)))
                 .ForMember(d => d.Dishes, opt => opt.ResolveUsing((order, viewModel, i, context) =>
                    {
                        return Mapper.Map<List<OrderDishViewModel>>(order.OrderParts);
                    }));
            CreateMap<Order, OrderHeaderViewModel>()
                .ForMember(d => d.OrderState, opt => opt.MapFrom(s => s.State))
                .ForMember(d => d.Price,
                    opt => opt.ResolveUsing((order, orderModel, i, context) =>
                    {
                        double cost = 0;
                        order.OrderParts.ForEach(x =>
                        {
                            cost += x.Dish.Price * x.Quantity;
                        });
                        return cost;
                    }))
                    .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Author));
            CreateMap<OrderViewModel, Order>();
            CreateMap<UserModel, User>();
            CreateMap<(User user, Role role), UserModel>()
                .ForMember(d => d.Role, opt => opt.MapFrom(s => s.role.Name))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.user.UserName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.user.Email));
            CreateMap<NewDishViewModel, Dish>();
            CreateMap<NewOrderModel, OrderPart>()
                .ForMember(d => d.Dish, opt => opt.MapFrom(s => s.Dish));
        }
    }
}