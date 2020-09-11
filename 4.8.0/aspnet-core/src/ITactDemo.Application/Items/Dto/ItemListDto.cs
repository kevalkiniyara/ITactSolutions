using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Items.Dto
{
    [AutoMapFrom(typeof(Item))]
    public class ItemListDto:EntityDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

    }
}
