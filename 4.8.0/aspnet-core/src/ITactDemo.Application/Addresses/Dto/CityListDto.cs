using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Addresses.Dto
{
    [AutoMap(typeof(State))]
    class CityListDto:EntityDto
    {
        public string CityName { get; set; }
        
        public int StateId { get; set; }

        public Student Student { get; set; }
    }
}
