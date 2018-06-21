using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Service.Identity;
using Restaurant.Service.Interfaces;

namespace Restaurant.Service.Service
{
    public class UserService : BaseService<User>, IUserService
    {

        public UserService(IUnitOfWork uow) : base (uow)
        { }

        public List<(User, Role)> GetAllUsersWithRoles()
        {
            var users = ((IEnumerable<User>)_uow.Get<User>().GetAll()).ToList();
            var roles = ((IEnumerable<Role>)_uow.Get<Role>().GetAll()).ToList();
            var usersWithRolesTuple = new List<(User, Role)>();
            users.ForEach(x =>
            {
                var role = roles.Where(y => y.Id == x.Roles.FirstOrDefault().RoleId)
                .FirstOrDefault();
                usersWithRolesTuple.Add((x, role));
            });
            return (usersWithRolesTuple);
        }
    }
}
