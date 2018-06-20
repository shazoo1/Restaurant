using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Restaurant.Service.Identity;
using Restaurant.Web.Models.Login;

namespace Restaurant.Web.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(LoginModel model)
        {
            var result = await SignInManager.PasswordSignInAsync(model.UserName,
                model.Password, model.IsPersistent, false);
            switch (result)
            {
                case SignInStatus.Success:
                    {
                        return RedirectToAction("Index", "Orders");
                    }
                default:
                    {
                        return RedirectToAction("Index", "Login");
                    }
            }
        }
    }
}