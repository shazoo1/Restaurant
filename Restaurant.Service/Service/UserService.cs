using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Service.Identity;
using Restaurant.Service.Interfaces;
using Restaurant.Service.Models;

namespace Restaurant.Service.Service
{
    public class UserService : BaseService<UserModel>, IUserService
    {

        public UserService(IUnitOfWork uow, IMapper mapper)
            : base (uow, mapper)
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

        public void CreateUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
        }
    }
}
