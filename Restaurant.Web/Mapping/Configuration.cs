using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Restaurant.Service.Mapping;
using static Restaurant.Web.Mapping.WebProfile;

namespace Restaurant.Web.Mapping
{
    public class Configuration
    {
        public static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile(new EntityToModel());
                cfg.AddProfile(new ModelToEntity());
                cfg.AddProfile(new ModelToViewModel());
                cfg.AddProfile(new ViewModelToModel());
                });
        }

        public static IMapper CreateMapper() => new Mapper(CreateConfiguration());
    }
}