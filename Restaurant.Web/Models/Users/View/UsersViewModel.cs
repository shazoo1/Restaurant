using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Domain.Identity.Entities;

namespace Restaurant.Web.Models.Users.View
{
    public class UsersViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public NewUserViewModel NewUser { get; set; } = new NewUserViewModel();
    }
}