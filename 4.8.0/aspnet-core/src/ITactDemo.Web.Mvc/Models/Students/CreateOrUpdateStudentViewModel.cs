using Abp.Application.Services.Dto;
using ITactDemo.Students.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Students
{
    public class CreateOrUpdateStudentViewModel
    {
        public CreateOrUpdateStudentDto Student;
        public List<ComboboxItemDto> HobbyList { get; set; }

        public List<ComboboxItemDto> StandardList { get; set; }

        public List<ComboboxItemDto> CountryList { get; set; }

        public List<ComboboxItemDto> StateList { get; set; }

        public List<ComboboxItemDto> CityList { get; set; }

        public CreateOrUpdateStudentViewModel(CreateOrUpdateStudentDto student,List<ComboboxItemDto> hobbyList,List<ComboboxItemDto> standardList,List<ComboboxItemDto> countryList, List<ComboboxItemDto> stateList, List<ComboboxItemDto> cityList)
        {
            Student = student;
            HobbyList = hobbyList;
            StandardList = standardList;
            CountryList = countryList;
            StateList = stateList;
            CityList = cityList;
        }
    }
}
