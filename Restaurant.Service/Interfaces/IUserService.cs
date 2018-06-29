using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Service.Models;

namespace Restaurant.Service.Interfaces
{
    public interface IUserService : IBaseService<UserModel>
    {
        List<(User, Role)> GetAllUsersWithRoles();
    }
}
