using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Addresses
{
    [AutoMap(typeof(Country))]
    class CountryListDto:EntityDto
    {
        public string CountryName { get; set; }
    }

}
