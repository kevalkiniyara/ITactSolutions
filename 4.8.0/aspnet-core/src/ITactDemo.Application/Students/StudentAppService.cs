using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.UI;
using ITactDemo.Addresses;
using ITactDemo.Authorization;
using ITactDemo.Grid;
using ITactDemo.Grid.Helper;
using ITactDemo.StudentHobbies;
using ITactDemo.Students.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Students
{
    [AbpAuthorize(PermissionNames.Pages_Students)]
    public class StudentAppService : ITactDemoAppServiceBase
    {
        #region Declaration

        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Hobby> _hobbiesRepository;

        private readonly IRepository<StudentHobby> _studentHobbiesRepository;
        private readonly IRepository<Country> _countryRepository;

        private readonly IRepository<State> _stateRepository;
        private readonly IRepository<City> _cityRepository;
        #endregion

        #region Constructor
        public StudentAppService(
            IRepository<Student> studentRepository,
            IRepository<Hobby> hobbiesRepository,
            IRepository<StudentHobby> studentHobbiesRepository,
            IRepository<Country> countryRepository, 
            IRepository<State> stateRepository,
            IRepository<City> cityRepository)
        {
            _studentRepository = studentRepository;
            _hobbiesRepository = hobbiesRepository;
            _studentHobbiesRepository = studentHobbiesRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }
        #endregion

        #region GetStudent
        public GridOutputDto<StudentListDto> GetStudentAsyc(GridSettings gridInput)
        {
            try
            {
                IQueryable<Student> query = _studentRepository.GetAll().Include(c=>c.StudentHobbies).ThenInclude(c=>c.Hobby)
                    .GridCommonSettings(gridInput, out int count).AsQueryable();

                GridOutputDto<StudentListDto> gridOutput = new GridOutputDto<StudentListDto>()
                {
                    Page = gridInput.PageIndex,
                    Total = (int)Math.Ceiling((double)count / gridInput.PageSize),
                    Records = count,
                    Rows = GetStudent(query)
                };
                return gridOutput;
            }
            catch(Exception ex)
            {
                GridOutputDto<StudentListDto> gridOutput = new GridOutputDto<StudentListDto>()
                {

                };
                return gridOutput;
            }
        }
        #endregion
        
        #region GetMethod
        public  List<StudentListDto> GetStudent(IQueryable<Student> student)
        {
            List<StudentListDto> studentListDto = student.Select(c => new StudentListDto {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Standard = c.Standard,
                BirthDate = c.BirthDate,
                Gender = c.Gender,
                StudentImage = !string.IsNullOrEmpty(c.StudentImage) ? Path.Combine(AppConsts.UploadFolderPath, c.StudentImage) : "",
                Hobbies = c.StudentHobbies != null  ? string.Join(", ", c.StudentHobbies.Select(d=>d.Hobby.HobbyName)) : ""
            }).ToList();
            return studentListDto;
        }
        #endregion

        #region Crud-Methods
        public async Task<CreateOrUpdateStudentDto> GetStudentForEdit(NullableIdDto input)
        {
            CreateOrUpdateStudentDto createOrUpdateStudentDto;
            if (input.Id.HasValue)
            {
                Student student = await _studentRepository.GetAll().Include(c=>c.StudentHobbies).FirstOrDefaultAsync(c=>c.Id == input.Id);
                
                createOrUpdateStudentDto = ObjectMapper.Map<CreateOrUpdateStudentDto>(student);
                createOrUpdateStudentDto.HobbiesIds = student.StudentHobbies.Select(c => (int?)c.HobbyId).ToArray();
                createOrUpdateStudentDto.StudentImagePic = !string.IsNullOrEmpty(student.StudentImage) ? Path.Combine(AppConsts.UploadFolderPathForEdit, student.StudentImage) : "";
            }
            else
            {
                createOrUpdateStudentDto = new CreateOrUpdateStudentDto();
            }
            return createOrUpdateStudentDto;
        }

        public async Task CreateOrUpdateStudent(CreateOrUpdateStudentDto input)
        {
            if (input.Id == 0)
            {
                await CreateStudentAsync(input);
            }
            else
            {
                await UpdateStudentAsync(input);
            }
        }

        public virtual async Task CreateStudentAsync(CreateOrUpdateStudentDto input)
        {
            try
            {
                List<StudentHobby> studentHobbies = new List<StudentHobby>();

                if (input.HobbiesIds.Count() > 0)
                {
                    foreach(int hid in input.HobbiesIds)
                    {
                        StudentHobby studentHobby = new StudentHobby();
                        studentHobby.HobbyId = hid;
                        studentHobbies.Add(studentHobby);
                    }
                }
                Student student = ObjectMapper.Map<Student>(input);
                student.StudentHobbies = studentHobbies;
                await _studentRepository.InsertAsync(student);
            }
            catch (DbUpdateException)
            {
                throw new UserFriendlyException(L("CRUD.CreateDependency"));
            }
        }

        public virtual async Task UpdateStudentAsync(CreateOrUpdateStudentDto input)
        {
            try
            {   
                List<StudentHobby> studentHobbies = new List<StudentHobby>();
                Student student = await _studentRepository.GetAll().Include(c => c.StudentHobbies).FirstOrDefaultAsync(c => c.Id == input.Id);
                
                if (student !=null)
                {   
                    foreach(var studentHobby in student.StudentHobbies)
                    {
                        await _studentHobbiesRepository.DeleteAsync(studentHobby);
                    }
                }
                if (student != null)
                {
                    if(input.HobbiesIds.Count()>0)
                    {
                        foreach (int hid in input.HobbiesIds)
                        {
                            StudentHobby studentHobby = new StudentHobby();
                            studentHobby.HobbyId = hid;
                            studentHobbies.Add(studentHobby);
                        }
                    }
                    ObjectMapper.Map(input, student);
                    student.StudentHobbies = studentHobbies;
                    await _studentRepository.UpdateAsync(student);
                }
            }
            catch (DbUpdateException)
            {
                throw new UserFriendlyException(L("CRUD.UpdateDependency"));
            }
        }

        public virtual async Task DeleteStudent(EntityDto input)
        {
            Student student = await _studentRepository.GetAll().Include(c => c.StudentHobbies).FirstOrDefaultAsync(c => c.Id == input.Id);

            if (student != null)
            {
                foreach (var studentHobby in student.StudentHobbies)
                {
                    await _studentHobbiesRepository.DeleteAsync(studentHobby);
                }
            }
            await _studentRepository.DeleteAsync(student);
            try
            {
                await CurrentUnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new UserFriendlyException(L("CRUD.DeleteDependency"));
            }
        }
        #endregion

        #region GetHobbies
        public List<ComboboxItemDto> GetHobbiesComboboxDto(int?[] hobbieId)
        {
            List<ComboboxItemDto> hobbiesComboboxDto;
            if(hobbieId!=null)
            {
                hobbiesComboboxDto = _hobbiesRepository.GetAll().Select(c => new ComboboxItemDto
                {
                    DisplayText = c.HobbyName,
                    Value = c.Id.ToString(),
                    IsSelected = hobbieId.Contains(c.Id) ? true : false
                }).OrderBy(c => c.DisplayText).ToList();
                return hobbiesComboboxDto;
            }
            else
            {
                hobbiesComboboxDto = _hobbiesRepository.GetAll().Select(c => new ComboboxItemDto
                {
                    DisplayText = c.HobbyName,
                    Value = c.Id.ToString(),
                }).OrderBy(c => c.DisplayText).ToList();
                return hobbiesComboboxDto;
            }
        }
        #endregion

        #region Standards
        public List<ComboboxItemDto> GetStandardComboboxDto(StandardEnum? standard)
        {
            List<ComboboxItemDto> standardComboboxDto = new List<ComboboxItemDto>();
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.First.ToString(),
                Value = ((int)StandardEnum.First).ToString(),
                IsSelected = StandardEnum.First == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Second.ToString(),
                Value = ((int)StandardEnum.Second).ToString(),
                IsSelected = StandardEnum.Second == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Third.ToString(),
                Value = ((int)StandardEnum.Third).ToString(),
                IsSelected = StandardEnum.Third == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Fourth.ToString(),
                Value = ((int)StandardEnum.Fourth).ToString(),
                IsSelected = StandardEnum.Fourth == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Fifth.ToString(),
                Value = ((int)StandardEnum.Fifth).ToString(),
                IsSelected = StandardEnum.Fifth == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Sixth.ToString(),
                Value = ((int)StandardEnum.Sixth).ToString(),
                IsSelected = StandardEnum.Sixth == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Seventh.ToString(),
                Value = ((int)StandardEnum.Seventh).ToString(),
                IsSelected = StandardEnum.Seventh == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Eighth.ToString(),
                Value = ((int)StandardEnum.Eighth).ToString(),
                IsSelected = StandardEnum.Eighth == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Ninth.ToString(),
                Value = ((int)StandardEnum.Ninth).ToString(),
                IsSelected = StandardEnum.Ninth == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Tenth.ToString(),
                Value = ((int)StandardEnum.Tenth).ToString(),
                IsSelected = StandardEnum.Tenth == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Eleventh.ToString(),
                Value = ((int)StandardEnum.Eleventh).ToString(),
                IsSelected = StandardEnum.Eleventh == standard
            });
            standardComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = StandardEnum.Twelveth.ToString(),
                Value = ((int)StandardEnum.Twelveth).ToString(),
                IsSelected = StandardEnum.Twelveth == standard
            });
            return standardComboboxDto;
        }
        #endregion

        #region Country
        public  List<ComboboxItemDto> GetCountryComboboxDto(int? countryId)
        {
            List<ComboboxItemDto> countryComboboxDto = _countryRepository.GetAll().Select(c => new ComboboxItemDto
            {
                DisplayText = c.CountryName,
                Value = c.Id.ToString(),
                IsSelected = c.Id  == countryId ? true : false
            }).OrderBy(c => c.DisplayText).ToList();
            return countryComboboxDto;
        }
        #endregion

        #region State
        public List<ComboboxItemDto> GetStateComboboxDto(int? countryId,int ? stateId)
        {
            List<ComboboxItemDto> stateComboboxDto = _stateRepository.GetAll().Where(c => c.CountryId == countryId).Select(c => new ComboboxItemDto
            {
                DisplayText = c.StateName,
                Value = c.Id.ToString(),
                IsSelected = c.Id == stateId ? true : false
            }).OrderBy(c => c.DisplayText).ToList();
            return stateComboboxDto;
        }
        #endregion

        #region City
        public List<ComboboxItemDto> GetCityComboboxDto(int? stateId,int? cityId)
        {
            List<ComboboxItemDto> cityComboboxDto = _cityRepository.GetAll().Where(c=>c.StateId == stateId).Select(c => new ComboboxItemDto
            {
                DisplayText = c.CityName,
                Value = c.Id.ToString(),
                IsSelected=c.Id== cityId ? true:false
            }).OrderBy(c => c.DisplayText).ToList();
            return cityComboboxDto;
        }
        #endregion
    }
}
