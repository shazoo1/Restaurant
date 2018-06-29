using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Web.Models.Users.View
{
    public class NewUserViewModel
    {
        public UserViewModel NewUser { get; set; }
        public IEnumerable<SelectListItem> UserRoles { get; set; }
        public Guid SelectedUserRoleId { get; set; }
    }
}