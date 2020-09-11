using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Categories.Dto
{
    [AutoMapTo(typeof(Category))]
    public class CategoryListDto:EntityDto
    {
        public string Name { get; set; }

    }
}
