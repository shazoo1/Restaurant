using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Service.Identity;

namespace Restaurant.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected UserManager UserManager => Request.GetOwinContext().GetUserManager<UserManager>();

        protected RoleManager RoleManager => Request.GetOwinContext().GetUserManager<RoleManager>();
        protected SignInManager SignInManager => HttpContext.GetOwinContext().Get<SignInManager>();
        protected IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
    }
}