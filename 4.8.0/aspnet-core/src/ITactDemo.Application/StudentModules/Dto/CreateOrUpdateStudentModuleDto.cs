using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Addresses;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.StudentModules.Dto
{
    [AutoMap(typeof(StudentModule))]
    public class CreateOrUpdateStudentModuleDto:EntityDto
    {
        public string StudentName { get; set; }

        public string Gender { get; set; }

        public StandardEnum Standard { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int StateId { get; set; }

        public State State { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
