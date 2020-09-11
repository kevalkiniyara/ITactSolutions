using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.StudentHobbies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Students.Dto
{
    [AutoMap(typeof(Hobby))]
    public class HobbyListDto: EntityDto
    {
        public string HobbyName { get; set; }
    }
}
