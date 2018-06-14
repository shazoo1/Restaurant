using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Web.Models.Order
{
    public class OrdersListModel
    {
        public List<OrderModel> OrdersList { get; set; }

        //TODO :: Remove when DB is implemented
        public OrdersListModel()
        {
            OrdersList = new List<OrderModel>();
            for (int i = 1; i <= 10; i++)
            {
                OrdersList.Add(new OrderModel {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                    Name = "Order " + i.ToString(),
                    OrderState = "New",
                    Price = 10,
                    TableNumber = i,
                    UserName = "Hardcode"
                });
            }
        }
    }
}