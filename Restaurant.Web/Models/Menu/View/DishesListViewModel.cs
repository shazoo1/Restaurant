using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant.Service.Models;

namespace Restaurant.Web.Models.Menu.View
{
    public class DishesListViewModel
    {
        public List<DishModel> Dishes { get; set; }
    }
}