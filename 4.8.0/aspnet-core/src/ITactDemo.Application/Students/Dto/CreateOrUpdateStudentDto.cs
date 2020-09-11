using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.StudentHobbies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Students.Dto
{
    [AutoMap(typeof(Student))]
    public class CreateOrUpdateStudentDto: EntityDto
    {
        [Required]
        [MaxLength(Student.MaxNameLength)]
        public string FirstName { get; set; }

        [MaxLength(Student.MaxNameLength)]
        public string LastName { get; set; }

        [MaxLength(Student.MaxNameLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(Student.MaxNumberLength)]
        public string PhoneNumber { get; set; }

        public StandardEnum Standard { get; set; }
      
        public DateTime BirthDate { get; set; }

        public int?[] HobbiesIds { get; set; }

        public int? CountryId { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public string Gender { get; set; }

        public string StudentImage { get; set; }

        public string StudentImagePic { get; set; }


    }
}
