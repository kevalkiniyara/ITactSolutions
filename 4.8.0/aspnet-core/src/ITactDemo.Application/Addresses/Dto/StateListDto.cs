using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Addresses.Dto
{
    [AutoMap(typeof(Country))]
    public class StateListDto:EntityDto
    {
        public string StateName { get; set; }

        public int CountryId { get; set; }
    }
}
