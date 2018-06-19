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
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
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
                Id = new Guid("1ABB568A-2ECD-43E6-B814-BE164CF2F6F4"),
                Email = "admin@admin.com",
                UserName = "admin"
            };
            var adminPassword = "AdminPassword";

            if(userManager.FindByName(superUser.UserName) == null)
            {
                userManager.Create(superUser, adminPassword);
                userManager.SetLockoutEnabled(superUser.Id, false);
            }
            var adminRole = RoleName.Admin;
            var rolesForUser = userManager.GetRoles(superUser.Id);
            if (!rolesForUser.Contains(adminRole))
                userManager.AddToRole(superUser.Id, RoleName.Admin);

            base.Seed(context);
        }
    }
}
