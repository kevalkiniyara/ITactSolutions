using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.EmployeeHobbies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.EmployeesHobbies.Dto
{
    [AutoMap(typeof(EmployeeHobby))]
    public class EmployeeHobbyListDto:EntityDto
    {
        public int? EmployeeId { get; set; }

        public int? HobbyId { get; set; }
    }
}
