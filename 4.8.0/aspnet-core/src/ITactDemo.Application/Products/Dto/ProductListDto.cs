using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Products.Dto
{
    [AutoMap(typeof(Product))]
    public class ProductListDto:EntityDto
    {
        public string ProductName { get; set; }
    }
}
