using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Domain.Identity.Entities;
using Restaurant.Web.Models.Users;
using AutoMapper;
using Restaurant.Service.Interfaces;
using System.Threading.Tasks;
using Restaurant.Web.Models.Users.View;

namespace Restaurant.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UsersController : BaseController
    {
        private UsersViewModel _model = new UsersViewModel();
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Users
        public ActionResult List()
        {
            _model.Users = Mapper.Map<List<UserModel>>
                (_userService.GetAllUsersWithRoles());
            _model.NewUser.UserRoles = new SelectList(RoleManager.Roles, "Id", "Name");
            return View(_model);
        }

        public async Task<ActionResult> Create(NewUserViewModel newUserViewModel)
        {
            var user = Mapper.Map<User>(newUserViewModel.NewUser);
            await UserManager.CreateAsync(user, newUserViewModel.NewUser.Password);
            user = await UserManager.FindByNameAsync(user.UserName);
            var userRole = await RoleManager.FindByIdAsync(newUserViewModel.SelectedUserRoleId);
            await UserManager.AddToRoleAsync(user.Id, userRole.Name);
            return RedirectToAction("List", "Users");
        }
    }
}