using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ITactDemo.Controllers;
using ITactDemo.Customers;
using ITactDemo.Customers.Dto;
using ITactDemo.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace ITactDemo.Web.Mvc.Controllers
{
    public class CustomersController : ITactDemoControllerBase
    {
        private readonly CustomerAppService _customerAppService;

        public CustomersController(CustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CreateOrUpdateCustomer(int? id)
        {
            CreateOrUpdateCustomerDto createOrUpdateCustomerDto = await _customerAppService.GetCustomerForEdit(new NullableIdDto { Id=id});
            List<ComboboxItemDto> productDto;
            if(id!=0)
            {
                productDto = _customerAppService.ProductComboboxDto(createOrUpdateCustomerDto.ProductIds);
            }
            productDto = _customerAppService.ProductComboboxDto(null);
            List<ComboboxItemDto> accountComboboxDto = _customerAppService.AccountTypeComboboxDto(createOrUpdateCustomerDto.AccountType);
            List<ComboboxItemDto> countryComboboxDto = _customerAppService.CountryComboBoxDto(createOrUpdateCustomerDto.CountryId);
            List<ComboboxItemDto> stateComboboxDto = _customerAppService.StateComboBoxDto(createOrUpdateCustomerDto.CountryId,createOrUpdateCustomerDto.StateId);
            List<ComboboxItemDto> cityComboboxDto = _customerAppService.CityComboBoxDto(createOrUpdateCustomerDto.StateId,createOrUpdateCustomerDto.CityId);
            CreateOrUpdateCustomerViewModel createOrUpdateCustomerViewModel = new CreateOrUpdateCustomerViewModel(createOrUpdateCustomerDto, productDto, countryComboboxDto, stateComboboxDto, cityComboboxDto, accountComboboxDto);
            return View(createOrUpdateCustomerViewModel);
        }
    }
}