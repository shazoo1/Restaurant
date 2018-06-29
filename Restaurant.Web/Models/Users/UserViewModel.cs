using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Identity.Entities;

namespace Restaurant.Web.Models.Users
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
    }
}