using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.CustomerProducts
{
    [AutoMap(typeof(CustomerProduct))]
    public class CustomerProductListDto:EntityDto
    {
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

    }
}
