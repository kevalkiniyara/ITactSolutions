using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITactDemo.Addresses;
using ITactDemo.Categories;
using ITactDemo.EmployeeHobbies;
using ITactDemo.EmployeeItems;
using ITactDemo.Employees.Dto;
using ITactDemo.Items;
using ITactDemo.Students;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITactDemo.Employees
{
    public class EmployeeAppService:ITactDemoAppServiceBase
    {
        #region Declaration
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Item> _itemRepository;

        private readonly IRepository<EmployeeItem> _employeeItemRepository;
        private readonly IRepository<Hobby> _hobbyRepository;

        private readonly IRepository<EmployeeHobby> _employeeHobbyRepository;
        private readonly IRepository<Country> _countryRepository;

        private readonly IRepository<State> _stateRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Category> _categoryRepository;
        #endregion

        #region Constructor
        public EmployeeAppService(
            IRepository<Employee> employeeRepository,
            IRepository<Item> itemRepository,
            IRepository<EmployeeItem> employeeItemRepository,
            IRepository<Hobby> hobbyRepository,
            IRepository<EmployeeHobby> employeeHobbyRepository,
            IRepository<Country> countryRepository,
            IRepository<State> stateRepository,
            IRepository<City> cityRepository,
            IRepository<Category> categoryRepository)
        {
            _employeeRepository = employeeRepository;
            _itemRepository = itemRepository;
            _employeeItemRepository = employeeItemRepository;
            _hobbyRepository = hobbyRepository;
            _employeeHobbyRepository = employeeHobbyRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _categoryRepository = categoryRepository;
        }
        #endregion

        public async Task<CreateOrUpdateEmployeeDto> GetEmployeeEdit(NullableIdDto input)
        {
            CreateOrUpdateEmployeeDto createOrUpdateEmployeeDto;
            if(input.Id.HasValue)
            {
                Employee employee = await _employeeRepository.GetAll().FirstOrDefaultAsync(c => c.Id == input.Id);
                createOrUpdateEmployeeDto = ObjectMapper.Map<CreateOrUpdateEmployeeDto>(employee);
            }
            else
            {
                createOrUpdateEmployeeDto = new CreateOrUpdateEmployeeDto();
            }
            return createOrUpdateEmployeeDto;
        }


        //public async Task CreateOrUpdateEmployee(CreateOrUpdateEmployeeDto input)
        //{
        //    if (input.Id == 0)
        //    {
        //        await CreateEmployee(input);
        //    }
        //    else
        //    {
        //        await UpdateEmployee(input);
        //    }
        //}

        //public async Task CreateEmployee(CreateOrUpdateEmployeeDto input)
        //{

        //}

        //public async Task UpdateEmployee(CreateOrUpdateEmployeeDto input)
        //{

        //}



        #region ProfessionComboBox
        public List<ComboboxItemDto> ProfessionComboBox(EmployeeProfessionEnum? profession)
        {
            List<ComboboxItemDto> professionComboboxDto = new List<ComboboxItemDto>();
            professionComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText=EmployeeProfessionEnum.BusinessAnalysis.ToString(),
                Value=((int)EmployeeProfessionEnum.BusinessAnalysis).ToString(),
                IsSelected=EmployeeProfessionEnum.BusinessAnalysis==profession
            });
            professionComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = EmployeeProfessionEnum.Employee.ToString(),
                Value = ((int)EmployeeProfessionEnum.Employee).ToString(),
                IsSelected = EmployeeProfessionEnum.Employee == profession
            });
            professionComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = EmployeeProfessionEnum.HumanResource.ToString(),
                Value = ((int)EmployeeProfessionEnum.HumanResource).ToString(),
                IsSelected = EmployeeProfessionEnum.HumanResource == profession
            });
            professionComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = EmployeeProfessionEnum.ProjectManager.ToString(),
                Value = ((int)EmployeeProfessionEnum.ProjectManager).ToString(),
                IsSelected = EmployeeProfessionEnum.ProjectManager == profession
            });
            professionComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = EmployeeProfessionEnum.TeamLead.ToString(),
                Value = ((int)EmployeeProfessionEnum.TeamLead).ToString(),
                IsSelected = EmployeeProfessionEnum.TeamLead == profession
            });
            return professionComboboxDto;
        }
        #endregion

        #region Hobby-ComboBox
        public List<ComboboxItemDto> GetHobbyComboboxDto(int?[] hobbieId)
        {
            List<ComboboxItemDto> hobbyComboboxDto;
            if (hobbieId != null)
            {
                hobbyComboboxDto = _hobbyRepository.GetAll().Select(c => new ComboboxItemDto
                {
                    DisplayText = c.HobbyName,
                    Value = c.Id.ToString(),
                    IsSelected = hobbieId.Contains(c.Id) ? true : false
                }).OrderBy(c => c.DisplayText).ToList();
                return hobbyComboboxDto;
            }
            else
            {
                hobbyComboboxDto = _hobbyRepository.GetAll().Select(c => new ComboboxItemDto
                {
                    DisplayText = c.HobbyName,
                    Value = c.Id.ToString(),
                }).OrderBy(c => c.DisplayText).ToList();
                return hobbyComboboxDto;
            }
        }
        #endregion

        #region CountryComboBox
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

        #region StateComboBox
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

        #region CityComboBox
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

        #region Item-ComboBox
        public List<ComboboxItemDto> CategoryComboBoxDto(int? categoryId)
        {
            List<ComboboxItemDto> categoryComboboxDto = _categoryRepository.GetAll().Select(c => new ComboboxItemDto
            {
                DisplayText = c.Name,
                Value = c.Id.ToString(),
                IsSelected = c.Id == categoryId ? true : false
            }).ToList();
            return categoryComboboxDto;
        }

        public List<ComboboxItemDto> ItemCombobox(int? categoryId,int? itemId)
        {
            List<ComboboxItemDto> itemComboboxDto = _itemRepository.GetAll().Where(c=>c.CategoryId==categoryId).Select(c => new ComboboxItemDto
            {
                DisplayText = c.Name,
                Value = c.Id.ToString(),
                IsSelected = c.Id == itemId ? true : false
            }).ToList();
            return itemComboboxDto;
        }

        public decimal GetItemPrice(int? itemId)
        {
            decimal amount = _itemRepository.GetAll().FirstOrDefault(c => c.Id == itemId).Price;
            return amount;
        }
        #endregion
    }
}
