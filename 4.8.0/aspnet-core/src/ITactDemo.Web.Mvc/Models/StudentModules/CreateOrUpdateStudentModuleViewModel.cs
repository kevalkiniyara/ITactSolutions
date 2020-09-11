using Abp.Application.Services.Dto;
using ITactDemo.StudentModules;
using ITactDemo.StudentModules.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.StudentModules
{
    public class CreateOrUpdateStudentModuleViewModel
    {
        public CreateOrUpdateStudentModuleDto StudentModule;

        public List<ComboboxItemDto> StandardList { get; set; }

        public List<ComboboxItemDto> CountryList { get; set; }

        public List<ComboboxItemDto> StateList { get; set; }

        public List<ComboboxItemDto> CityList { get; set; }

        public CreateOrUpdateStudentModuleViewModel(CreateOrUpdateStudentModuleDto studentModule,List<ComboboxItemDto> standardList,List<ComboboxItemDto> countryList, List<ComboboxItemDto> stateList, List<ComboboxItemDto> cityList)
        {
            StudentModule = studentModule;
            StandardList = standardList;
            CountryList = countryList;
            StateList = stateList;
            CityList = cityList;
        }
    }
}
