using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Addresses
{
    public class CountryListViewModel
    {
        public List<ComboboxItemDto> CountryList { get; set; }

        public CountryListViewModel(List<ComboboxItemDto> countryList)
        {
            CountryList = countryList;
        }
    }
}
