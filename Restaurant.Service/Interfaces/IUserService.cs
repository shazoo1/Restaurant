using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Identity.Entities;

namespace Restaurant.Service.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        List<(User, Role)> GetAllUsersWithRoles();
    }
}
