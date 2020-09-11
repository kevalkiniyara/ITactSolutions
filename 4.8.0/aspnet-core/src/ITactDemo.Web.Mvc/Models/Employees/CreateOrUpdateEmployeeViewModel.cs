using Abp.Application.Services.Dto;
using ITactDemo.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Employees
{
    public class CreateOrUpdateEmployeeViewModel
    {
        public CreateOrUpdateEmployeeDto Employee;
        
        public List<ComboboxItemDto> ProfessionList { get; set; }

        public List<ComboboxItemDto> HobbyList { get; set; }

        public List<ComboboxItemDto> CountryList { get; set; }

        public List<ComboboxItemDto> StateList { get; set; }

        public List<ComboboxItemDto> CityList { get; set; }

        public List<ComboboxItemDto> CategoryList { get; set; }

        public List<ComboboxItemDto> ItemList { get; set; }
        

        public CreateOrUpdateEmployeeViewModel(
            CreateOrUpdateEmployeeDto employee,
            List<ComboboxItemDto> professionList,
            List<ComboboxItemDto> hobbyList,
            List<ComboboxItemDto> countryList,
            List<ComboboxItemDto> stateList,
            List<ComboboxItemDto> cityList,
            List<ComboboxItemDto> categoryList,
            List<ComboboxItemDto> itemList
            )
        {
            Employee = employee;
            ProfessionList = professionList;
            HobbyList = hobbyList;
            CountryList = countryList;
            StateList = stateList;
            CityList = cityList;
            CategoryList = categoryList;
            ItemList = itemList;
        }
    }
}
