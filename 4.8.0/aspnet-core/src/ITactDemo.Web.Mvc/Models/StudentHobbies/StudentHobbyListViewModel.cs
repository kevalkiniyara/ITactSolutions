using ITactDemo.StudentHobbies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.StudentHobbies
{
    public class StudentHobbyListViewModel
    {
        public StudentHobbyListDto StudentHobbyListDto { get; set; }

        public StudentHobbyListViewModel(StudentHobbyListDto studentHobbyListDto)
        {
            StudentHobbyListDto = studentHobbyListDto;
        }
    }
}
