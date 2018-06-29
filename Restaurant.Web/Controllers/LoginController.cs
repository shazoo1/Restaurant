using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Restaurant.Service.Identity;
using Restaurant.Web.Models.Login;

namespace Restaurant.Web.Controllers
{
    public class LoginController : BaseController
    {
        
        public LoginController(IMapper mapper) : base(mapper) { }
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.UserName,
                model.Password, model.IsPersistent, false);
                switch (result)
                {
                    case SignInStatus.Success:
                        {
                            return RedirectToAction("Index", "Orders");
                        }
                    case SignInStatus.Failure:
                        {
                            ModelState.AddModelError("Password", "Неверное имя пользователя или пароль");
                            ModelState.AddModelError("UserName", new Exception());
                            break;
                        }
                    default:
                        {
                            return View(model);
                        }
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            SignInManager.AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}