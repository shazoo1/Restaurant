using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant.Domain.Enums;

namespace Restaurant.Web.Models.Order.View
{
    public class OrderListViewModel
    {
        public List<OrderViewModel> OrderList { get; set; }
        [Display(Name = "По номеру")]
        public int? FilterTableNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "По дате")]
        public DateTime? FilterDate { get; set; }
        [Display(Name = "По статусу заказа")]
        public OrderState? FilterState { get; set; }
        public bool IsWaiter { get; set; }
        public bool IsCook { get; set; }
        public bool IsAdmin { get; set; }
    }
}