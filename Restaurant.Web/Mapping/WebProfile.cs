using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Web.Models.Menu;

namespace Restaurant.Web.Mapping
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<Dish, DishModel>();
            CreateMap<DishModel, Dish>();
        }
    }
}