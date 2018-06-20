using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Web.Models.Users;
using AutoMapper;

namespace Restaurant.Web.Helpers
{
    public class UserRoleHelper
    {
        public List<UserModel> FormUserModel(IQueryable<User> users,
            IQueryable<Role> roles)
        {
            var roleList = ((IEnumerable<Role>)roles).ToList();
            var userModels = Mapper.Map<List<UserModel>>(users);
            userModels.ForEach(x =>
            {
                x.Role = roleList.Where(z => z.Id == x.RoleId).FirstOrDefault().Name;
            });
            
            return null;
        }
    }
}