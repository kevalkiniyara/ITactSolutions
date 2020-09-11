using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Timing;
using Abp.UI;
using ITactDemo.Controllers;
using ITactDemo.Grid;
using ITactDemo.Students;
using ITactDemo.Students.Dto;
using ITactDemo.Web.Models.Hobbies;
using ITactDemo.Web.Models.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITactDemo.Web.Mvc.Controllers
{
    public class StudentsController : ITactDemoControllerBase
    {
        #region Declaration
        private readonly StudentAppService _studentAppService;
        #endregion

        #region Constructor Declaration
        public StudentsController(StudentAppService studentsAppService)
        {
            _studentAppService = studentsAppService;
        }
        #endregion

        #region Actions

        public JsonResult GetStudent(GridSettings gridSettings)
        {
            GridOutputDto<StudentListDto> student = _studentAppService.GetStudentAsyc(gridSettings);
            return Json(student);
        }

        public ActionResult Index()
        {
            //List<StudentListDto> studentListDto = await _studentAppService.GetStudent();
            //StudentListViewModel studentListViewModel = new StudentListViewModel(studentListDto);
            //return View(studentListViewModel);
            return View();
        }

        public async Task<ActionResult> CreateOrEditStudent(int? id)
        {
            CreateOrUpdateStudentDto createOrUpdateStudentDto = await _studentAppService.GetStudentForEdit(new NullableIdDto { Id = id });
            List<ComboboxItemDto> hobbyComboboxDto;
            if (id==null)
            {
                createOrUpdateStudentDto.BirthDate = DateTime.Now.Date;
                hobbyComboboxDto = _studentAppService.GetHobbiesComboboxDto(null);
            }
            else
            {
                hobbyComboboxDto = _studentAppService.GetHobbiesComboboxDto(null);
            }
            List<ComboboxItemDto> standardComboboxDto = _studentAppService.GetStandardComboboxDto(null);
            List<ComboboxItemDto> countryComboboxDto = _studentAppService.GetCountryComboboxDto(null);
            List<ComboboxItemDto> stateComboboxDto = _studentAppService.GetStateComboboxDto(null, null);
            List<ComboboxItemDto> cityComboboxDto = _studentAppService.GetCityComboboxDto(null, null);
            CreateOrUpdateStudentViewModel createOrUpdateStudentViewModel = new CreateOrUpdateStudentViewModel(createOrUpdateStudentDto, hobbyComboboxDto, standardComboboxDto,countryComboboxDto, stateComboboxDto, cityComboboxDto);
            return View(createOrUpdateStudentViewModel);
        }

        [HttpPost]
        public async Task CreateOrEditStudent(CreateOrUpdateStudentDto input)
        {
            if (Request.Form.Files.Count > 0)
            {
                if (!Directory.Exists(Path.Combine(AppConsts.rootPath, AppConsts.UploadFolderPath)))
                {
                    Directory.CreateDirectory(Path.Combine(AppConsts.rootPath, AppConsts.UploadFolderPath));
                }
                string[] fileExtensionArray = new string[] { ".png", ".jpg", ".jpeg" };

                foreach (IFormFile file in Request.Form.Files)
                {
                    if (file != null)
                    {
                        string fileSavePath = Path.Combine(AppConsts.rootPath, AppConsts.UploadFolderPath);
                        string fileExtension = Path.GetExtension(file.FileName);
                        if (!fileExtensionArray.Contains(fileExtension))
                        {
                            throw new UserFriendlyException("Please select of jpg,.png,.JPEG");
                        }
                        input.StudentImage = Guid.NewGuid() + Clock.Now.ToString("yyMMddHHmm") + fileExtension;

                        using (FileStream stream = new FileStream(Path.Combine(fileSavePath, input.StudentImage), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
            }
            await _studentAppService.CreateOrUpdateStudent(input);
        }
        
        public ActionResult DummyBootstrap()
        {
            return View();

        }
        public ActionResult PracticeStudent()
        {
            return View();
        }
        
        #endregion
    }
}