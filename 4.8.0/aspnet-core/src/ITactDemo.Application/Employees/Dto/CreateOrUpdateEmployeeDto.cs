using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.EmployeeItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Employees.Dto
{
    [AutoMap(typeof(Employee))]
    public class CreateOrUpdateEmployeeDto:EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public EmployeeProfessionEnum Profession { get; set; }

        public string Gender { get; set; }

        public string EmployeeImage { get; set; }

        public int? CountryId { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public int? CategoryId { get; set; }

        public int? ItemId { get; set; }

        public ICollection<EmployeeItem> EmployeeItems { get; set; }

        public decimal Price { get; set; }

        public int?[] HobbiesIds { get; set; }
    }
}
