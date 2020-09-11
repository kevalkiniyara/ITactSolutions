using Abp.Application.Services.Dto;
using ITactDemo.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Students
{
    public class StudentListViewModel
    {
        public List<StudentListDto> StudentList { get; set; }

        public StudentListViewModel(List<StudentListDto> studentList)
        {
            StudentList = studentList;
        }
    }
}
