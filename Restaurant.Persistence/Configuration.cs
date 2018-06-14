using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Domain.Identity.Store;

namespace Restaurant.Persistence
{
    public class Configuration : DbMigrationsConfiguration<RestaurantDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestaurantDbContext context)
        {
            var userManager = new UserManager<User, Guid>(new UserStore(context));
            var roleManager = new RoleManager<Role, Guid>(new RoleStore(context));

            var roles = typeof(RoleName).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(x => x.Name).ToList();

            roles.ForEach(roleName =>
            {
                if (!roleManager.RoleExists(roleName))
                {
                    roleManager.Create(new Role { Id = Guid.NewGuid(), Name = roleName });
                }
            });

            var superUser = new User
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Email = "admin@admin.com",
                UserName = "admin"
            };
            var adminPassword = "admin";

            if(userManager.FindByName(superUser.UserName) == null)
            {
                userManager.Create(superUser, adminPassword);
                userManager.SetLockoutEnabled(superUser.Id, false);
            }
            var adminRole = RoleName.ADMIN;
            var rolesForUser = userManager.GetRoles(superUser.Id);
            if (!rolesForUser.Contains(adminRole))
                userManager.AddToRole(superUser.Id, RoleName.ADMIN);

            base.Seed(context);
        }
    }
}
