﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Domain.Enums;

namespace Restaurant.Web.Models.Users
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public Guid RoleId { get; set; }
    }
}