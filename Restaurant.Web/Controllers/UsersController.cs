using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Web.Models.Users;
using AutoMapper;
using Restaurant.Web.Helpers;

namespace Restaurant.Web.Controllers
{
    public class UsersController : BaseController
    {
        private UsersViewModel _model = new UsersViewModel();
        // GET: Users
        public ActionResult List()
        {
            var helper = new UserRoleHelper();
            var users = UserManager.Users;
            var roles = RoleManager.Roles;
            helper.FormUserModel(users, roles);

            return View(_model);
        }
    }
}