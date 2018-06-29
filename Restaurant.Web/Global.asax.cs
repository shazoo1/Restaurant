using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Restaurant.Web.Mapping;

namespace Restaurant.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Mapper.Initialize(config => config.AddProfile<WebProfile>());
            /*var migrationConfig = new Persistence.Configuration();
            var migrator = new DbMigrator(migrationConfig);
            migrator.Update();*/
        }
    }
}
