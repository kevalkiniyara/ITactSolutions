using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Items;
using ITactDemo.OrderItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Orders.Dto
{
    [AutoMapFrom(typeof(Order))]
    public class OrderListDto:EntityDto
    {
        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public string Description { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public int Item { get; set; }

        public string ItemName { get; set; }

        //public string ItemValue { get; set; }

        public decimal Price { get; set; }

        //public int ItemQuantity { get; set; }
    }
}
