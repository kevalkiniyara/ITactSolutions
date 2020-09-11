using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ITactDemo.Controllers;
using ITactDemo.Employees;
using ITactDemo.Employees.Dto;
using ITactDemo.Web.Models.Employees;
using Microsoft.AspNetCore.Mvc;

namespace ITactDemo.Web.Mvc.Controllers
{
    public class EmployeesController : ITactDemoControllerBase
    {
        private readonly EmployeeAppService _employeeAppService;

        public EmployeesController(EmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CreateOrUpdateEmployee(int? id)
        {
            CreateOrUpdateEmployeeDto createOrUpdateEmployee = await _employeeAppService.GetEmployeeEdit(new NullableIdDto { Id = id });
            List<ComboboxItemDto> professionCombobox = _employeeAppService.ProfessionComboBox(null);

            List<ComboboxItemDto> hobbyCombobox = _employeeAppService.GetHobbyComboboxDto(null);
            List<ComboboxItemDto> countryComboboxDto = _employeeAppService.GetCountryComboboxDto(createOrUpdateEmployee.CountryId);

            List<ComboboxItemDto> stateComboboxDto = _employeeAppService.GetStateComboboxDto(createOrUpdateEmployee.CountryId, createOrUpdateEmployee.StateId);
            List<ComboboxItemDto> cityComboboxDto = _employeeAppService.GetCityComboboxDto(createOrUpdateEmployee.StateId, createOrUpdateEmployee.CityId);

            List<ComboboxItemDto> categoryComboboxDto = _employeeAppService.CategoryComboBoxDto(null);
            List<ComboboxItemDto> itemComboboxDto = _employeeAppService.ItemCombobox(null, null);

            CreateOrUpdateEmployeeViewModel employeeViewModel = new CreateOrUpdateEmployeeViewModel(createOrUpdateEmployee, professionCombobox, hobbyCombobox, countryComboboxDto, stateComboboxDto, cityComboboxDto, categoryComboboxDto, itemComboboxDto);
            return View(employeeViewModel);
        }
    }
}