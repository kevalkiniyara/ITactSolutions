using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Addresses;
using ITactDemo.StudentHobbies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Students.Dto
{
    [AutoMapFrom(typeof(Student))]
    public class StudentListDto: EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public StandardEnum Standard { get; set; }

        public DateTime BirthDate { get; set; }

        public Country Country { get; set; }

        public State State { get; set; }

        public City City { get; set; }

        public string Gender { get; set; }

        public  string Hobbies { get; set; }

        public string StudentImage { get; set; }

    }
}
