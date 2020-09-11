using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ITactDemo.Controllers;
using ITactDemo.StudentModules;
using ITactDemo.StudentModules.Dto;
using ITactDemo.Web.Models.StudentModules;
using Microsoft.AspNetCore.Mvc;

namespace ITactDemo.Web.Mvc.Controllers
{
    public class StudentModulesController : ITactDemoControllerBase
    {
        private readonly StudentModuleAppService _studentModuleAppService;

        public StudentModulesController(StudentModuleAppService studentModuleAppService)
        {
            _studentModuleAppService = studentModuleAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CreateOrEditStudentModule(int? id)
        {
            CreateOrUpdateStudentModuleDto createOrUpdateStudentModuleDto = await _studentModuleAppService.GetStudentForEdit(new NullableIdDto { Id = id });
            
            List<ComboboxItemDto> standardComboboxDto = _studentModuleAppService.GetStandardComboboxDto(null);
            List<ComboboxItemDto> countryComboboxDto = _studentModuleAppService.GetCountryComboboxDto(null);

            List<ComboboxItemDto> stateComboboxDto = _studentModuleAppService.GetStateComboboxDto(null, null);
            List<ComboboxItemDto> cityComboboxDto = _studentModuleAppService.GetCityComboboxDto(null, null);
            CreateOrUpdateStudentModuleViewModel createOrUpdateStudentModuleViewModel = new CreateOrUpdateStudentModuleViewModel(createOrUpdateStudentModuleDto, standardComboboxDto, countryComboboxDto, stateComboboxDto, cityComboboxDto);
            return View(createOrUpdateStudentModuleViewModel);
        }
        [HttpPost]
        public async Task CreateOrEditStudentModule(CreateOrUpdateStudentModuleDto input)
        {
            await _studentModuleAppService.CreateOrUpdateStudent(input);
        }
    }
}