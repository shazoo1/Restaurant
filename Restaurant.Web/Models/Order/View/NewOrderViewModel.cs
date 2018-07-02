using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Restaurant.Domain.Entities;
using Restaurant.Service.Models;

namespace Restaurant.Web.Models.Order.View
{
    public class NewOrderViewModel
    {
        [Display(Name = "Номер стола")]
        [Required(ErrorMessage ="Введите номер стола.")]
        public int TableNumber { get; set; }
        public List<OrderPartViewModel> OrderParts { get; set; } = new List<OrderPartViewModel>();
        public List<DishModel> AllDishes { get; set; } = new List<DishModel>();
    }
}