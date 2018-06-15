using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Persistence.Mapping;

namespace Restaurant.Persistence
{
    public class RestaurantDbContext : IdentityDbContext<User, Role, Guid, UserLogin, UserRole, UserClaim>, IRestaurantDbContext
    {
        public RestaurantDbContext() : base("RestaurantDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RestaurantDbContext, Configuration>());
            Database.Log = e => Debug.WriteLine($"RestaurantDbContext: {e}");
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbContext DbContext { get => this;}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());

        }
    }
}
