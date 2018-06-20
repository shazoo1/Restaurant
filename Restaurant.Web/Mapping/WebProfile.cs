using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Web.Models.Menu;
using Restaurant.Web.Models.Order;
using Restaurant.Web.Models.Users;

namespace Restaurant.Web.Mapping
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<Dish, DishModel>();
            CreateMap<DishModel, Dish>();
            CreateMap<Order, OrderModel>()
                .ForMember(d => d.OrderState, opt => opt.MapFrom(s => s.State))
                .ForMember(d => d.Price,
                    opt => opt.ResolveUsing((order, orderModel, i, context) => {
                        double cost = 0;
                        order.Dishes.ForEach(x =>
                        {
                            cost += x.Dish.Price * x.Quantity;
                        });
                        return cost;
                    }));
            CreateMap<OrderModel, Order>();
            CreateMap<User, UserModel>()
                .ForMember(s => s.RoleId, opt=>opt.ResolveUsing(
                    (user, userModel, i, context) => {
                        return user.Roles.FirstOrDefault().RoleId;
                    }
                    ));
            CreateMap<UserModel, User>();
        }
    }
}