using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Restaurant.Domain.Identity.Entities;

namespace Restaurant.Service.Identity
{
    public class RoleManager : RoleManager<Role, Guid>
    {
        public RoleManager(IRoleStore<Role, Guid> roleStore) : base(roleStore) { }
    }
}
