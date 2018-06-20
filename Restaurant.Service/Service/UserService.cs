using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Service.Identity;

namespace Restaurant.Service.Service
{
    public class UserService
    {
        UserManager _userManager;
        RoleManager _roleManager;

        public UserService(UserManager userManager, RoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
    }
}
