using Abp.Application.Services.Dto;
using ITactDemo.Customers;
using ITactDemo.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Customers
{
    public class CreateOrUpdateCustomerViewModel
    {
        public CreateOrUpdateCustomerDto Customer;

        public List<ComboboxItemDto> ProductList { get; set; }
        public List<ComboboxItemDto> CountryList { get; set; }
        public List<ComboboxItemDto> StateList { get; set; }
        public List<ComboboxItemDto> CityList { get; set; }
        public List<ComboboxItemDto> AccountList { get; set; }

        public CreateOrUpdateCustomerViewModel(CreateOrUpdateCustomerDto customer, List<ComboboxItemDto> productList, List<ComboboxItemDto> countryList, List<ComboboxItemDto> stateList, List<ComboboxItemDto> cityList, List<ComboboxItemDto> accountList)
        {
            Customer = customer;
            ProductList = productList;
            CountryList = countryList;
            StateList = stateList;
            CityList = cityList;
            AccountList = accountList;
        }
    }
}
