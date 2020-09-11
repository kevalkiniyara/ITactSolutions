using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.ItemTables.Dto
{
    [AutoMap(typeof(ItemTable))]
    public class CreateOrUpdateItemTableDto:EntityDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
