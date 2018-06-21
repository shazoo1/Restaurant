using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Domain.Identity.Entities
{
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>, IEntity
    {
    }
}
