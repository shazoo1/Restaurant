using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Domain.Identity.Store
{
    public class UserStore : UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public UserStore(IRestarauntDbContext context) : base(context.DbContext) { }
    }
}
