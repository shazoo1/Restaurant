using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Domain.Identity.Store;
using Restaurant.Domain.Interfaces;
using Restaurant.Service.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Restaurant.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<IRestaurantDbContext>());

            app.CreatePerOwinContext<IRoleStore<Role, Guid>>((options, context) =>
                new RoleStore(context.Get<IRestaurantDbContext>()));
            app.CreatePerOwinContext<IUserStore<User, Guid>>((options, context) =>
                new UserStore(context.Get<IRestaurantDbContext>()));

            app.CreatePerOwinContext<UserManager>((options, context) => new UserManager(options, context.Get<IUserStore<User, Guid>>()));

            app.CreatePerOwinContext<RoleManager>((options, context) => new RoleManager(context.Get<IRoleStore<Role, Guid>>()));

            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/"),
            });
        }
    }
}