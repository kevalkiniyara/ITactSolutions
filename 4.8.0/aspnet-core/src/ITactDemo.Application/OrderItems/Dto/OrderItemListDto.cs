using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.ItemTables;
using ITactDemo.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.OrderItems.Dto
{
    [AutoMapFrom(typeof(OrderItem))]
    public class OrderItemListDto:EntityDto
    {
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int? ItemId { get; set; }

        public virtual ItemTable Item { get; set; }

        public decimal Price { get; set; }

        public string ItemName { get; set; }


    }
}
