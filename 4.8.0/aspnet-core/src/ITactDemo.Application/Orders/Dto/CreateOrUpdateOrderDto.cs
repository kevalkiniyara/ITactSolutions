using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.OrderItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITactDemo.Orders.Dto
{
    [AutoMap(typeof(Order))]
    public class CreateOrUpdateOrderDto:EntityDto
    {
        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [MaxLength(Order.MaxNameLength)]
        public string Description { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public int? CategoryId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
