using Abp.Application.Services.Dto;
using ITactDemo.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Orders
{
    public class OrderListViewModel
    {
        public OrderListDto Order;
        public OrderListViewModel(OrderListDto order)
        {
            Order = order;
            
        }
    }
}
