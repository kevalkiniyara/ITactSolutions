using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITactDemo.Addresses;
using ITactDemo.StudentModules.Dto;
using ITactDemo.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITactDemo.StudentModules
{
    public class StudentModuleAppService: ITactDemoAppServiceBase
    {
        public readonly IRepository<StudentModule> _studentModule;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<State> _stateRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IStudentModuleRepository _studentModuleRepository;

        public StudentModuleAppService(IRepository<StudentModule> studentModule, 
            IRepository<Country> countryRepository, 
            IRepository<State> stateRepository, 
            IRepository<City> cityRepository,
            IStudentModuleRepository studentModuleRepository)
        {
            _studentModule = studentModule;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _studentModuleRepository = studentModuleRepository;
        }
        #region Crud-Operations
        public async Task<CreateOrUpdateStudentModuleDto> GetStudentForEdit(NullableIdDto input)
        {
            CreateOrUpdateStudentModuleDto createOrUpdateStudenModuleDto;
            if (input.Id.HasValue)
            {
                StudentModule student = await _studentModule.GetAll().FirstOrDefaultAsync(c => c.Id == input.Id);
                createOrUpdateStudenModuleDto = ObjectMapper.Map<CreateOrUpdateStudentModuleDto>(student);
            }
            else
            {
                createOrUpdateStudenModuleDto = new CreateOrUpdateStudentModuleDto();
            }
            return createOrUpdateStudenModuleDto;
        }

        public async Task CreateOrUpdateStudent(CreateOrUpdateStudentModuleDto input)
        {
            if (input.Id == 0)

            {
                await CreateStudentAsync(input);
            }
            
        }

        public virtual async Task CreateStudentAsync(CreateOrUpdateStudentModuleDto input)
        {
            try
            {
                StudentModule student = ObjectMapper.Map<StudentModule>(input);
                await _studentModuleRepository.CreateStudentModule(student);
                
                await _studentModule.InsertAsync(student);
            }
            catch (DbUpdateException)
            {
                throw new UserFriendlyException(L("CRUD.CreateDependency"));
            }
        }
        #endregion

        #region Standard
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
        public List<ComboboxItemDto> GetCountryComboboxDto(int? countryId)
        {
            List<ComboboxItemDto> countryComboboxDto = _countryRepository.GetAll().Select(c => new ComboboxItemDto
            {
                DisplayText = c.CountryName,
                Value = c.Id.ToString(),
                IsSelected = c.Id == countryId ? true : false
            }).OrderBy(c => c.DisplayText).ToList();
            return countryComboboxDto;
        }
        #endregion

        #region State
        public List<ComboboxItemDto> GetStateComboboxDto(int? countryId, int? stateId)
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
        public List<ComboboxItemDto> GetCityComboboxDto(int? stateId, int? cityId)
        {
            List<ComboboxItemDto> cityComboboxDto = _cityRepository.GetAll().Where(c => c.StateId == stateId).Select(c => new ComboboxItemDto
            {
                DisplayText = c.CityName,
                Value = c.Id.ToString(),
                IsSelected = c.Id == cityId ? true : false
            }).OrderBy(c => c.DisplayText).ToList();
            return cityComboboxDto;
        }
        #endregion
    }


}
