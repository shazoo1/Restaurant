using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Web.Models.Login
{
    public class LoginViewModel
    {
        [Display(Name="Имя пользователя", Prompt="Имя пользователя")]
        public string UserName { get; set; }
        [Display(Name="Пароль", Prompt = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Запомнить меня")]
        public bool IsPersistent { get; set; }
    }
}