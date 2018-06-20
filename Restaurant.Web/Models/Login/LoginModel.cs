using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Web.Models.Login
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}