using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Addresses
{
    public class CityListViewModel
    {
        public List<ComboboxItemDto> CityList { get; set; }

        public CityListViewModel(List<ComboboxItemDto> cityList)
        {
            CityList = cityList;
        }
    }
}
