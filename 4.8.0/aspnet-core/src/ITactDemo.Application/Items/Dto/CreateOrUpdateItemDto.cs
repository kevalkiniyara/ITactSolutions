using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Items.Dto
{
    [AutoMap(typeof(Item))]
    class CreateOrUpdateItemDto:EntityDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string ItemImage { get; set; }
    }
}
