using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Identity.Entities;

namespace Restaurant.Web.Models.Users
{
    public class UsersViewModel
    {
        public List<UserModel> Users { get; set; }
        public UserModel NewUser { get; set; }
    }
}