using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.StudentHobbies
{
    [AutoMap(typeof(StudentHobby))]
    public class StudentHobbyListDto:EntityDto
    {
        public int StudentId { get; set; }

        public int HobbyId { get; set; }


    }
}
