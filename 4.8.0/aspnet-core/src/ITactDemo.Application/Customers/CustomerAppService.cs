using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITactDemo.Addresses;
using ITactDemo.CustomerProducts;
using ITactDemo.Customers.Dto;
using ITactDemo.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITactDemo.Customers
{
    public class CustomerAppService:ITactDemoAppServiceBase
    {
        #region Declaration
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<CustomerProduct> _customerProductRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<State> _stateRepository;
        private readonly IRepository<City> _cityRepository;
        #endregion

        #region Constructor
        public CustomerAppService(IRepository<Customer> customerRepository,IRepository<Product> productRepository,IRepository<CustomerProduct> customerProductRepository,IRepository<Country> countryRepository,IRepository<State> stateRepository,IRepository<City> cityRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _customerProductRepository = customerProductRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        #endregion

        #region AccountTypeComboBox
        public  List<ComboboxItemDto> AccountTypeComboboxDto(CustomerEnumType? account)
        {
            List<ComboboxItemDto> accountTypeComboboxDto = new List<ComboboxItemDto>();
            accountTypeComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = CustomerEnumType.Default.ToString(),
                Value = ((int)CustomerEnumType.Default).ToString(),
                IsSelected = CustomerEnumType.Default == account
            });
            accountTypeComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = CustomerEnumType.Premium.ToString(),
                Value = ((int)CustomerEnumType.Premium).ToString(),
                IsSelected = CustomerEnumType.Premium == account
            });
            accountTypeComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = CustomerEnumType.Primary.ToString(),
                Value = ((int)CustomerEnumType.Primary).ToString(),
                IsSelected = CustomerEnumType.Primary == account
            });

            accountTypeComboboxDto.Add(new ComboboxItemDto
            {
                DisplayText = CustomerEnumType.Standard.ToString(),
                Value = ((int)CustomerEnumType.Standard).ToString(),
                IsSelected = CustomerEnumType.Standard == account
            });
            return accountTypeComboboxDto;
        }
        #endregion

        public async Task<CreateOrUpdateCustomerDto> GetCustomerForEdit(NullableIdDto Input)
        {
            CreateOrUpdateCustomerDto createOrUpdateCustomerDto;
            if (Input.Id.HasValue)
            {
                Customer customer = await _customerRepository.GetAll().Include(c => c.CustomerProducts).FirstOrDefaultAsync(c => c.Id == Input.Id);
                createOrUpdateCustomerDto = ObjectMapper.Map<CreateOrUpdateCustomerDto>(customer);
                createOrUpdateCustomerDto.ProductIds = customer.CustomerProducts.Select(c => (int?)c.Id).ToArray();
            }
            else
            {
                createOrUpdateCustomerDto = new CreateOrUpdateCustomerDto();
            }
            return createOrUpdateCustomerDto;
        }

        public async Task CreateOrUpdateCustomer(CreateOrUpdateCustomerDto input)
        {
            if(input.Id==0)
            {
                await CreateCustomer(input);
            }
            
        }

        public async Task CreateCustomer(CreateOrUpdateCustomerDto input)
        {
            List<CustomerProduct> customerProduct = new List<CustomerProduct>();
            if(input.ProductIds.Count()>0)
            {
                foreach(var productId in input.ProductIds)
                {
                    CustomerProduct products = new CustomerProduct();
                    products.ProductId = productId;
                    customerProduct.Add(products);
                }
                Customer customer = ObjectMapper.Map<Customer>(input);
                customer.CustomerProducts = customerProduct;
                await _customerRepository.InsertAsync(customer);
            }
        }

        public void UpdateCustomer(CreateOrUpdateCustomerDto input)
        {

        }


        #region CountryCombobox,StateCombobox,CityCombobox
        public List<ComboboxItemDto> CountryComboBoxDto(int? countryId)
        {
            List<ComboboxItemDto> countryComboboxDto = _countryRepository.GetAll().Select(c => new ComboboxItemDto
            {
                DisplayText = c.CountryName,
                Value = c.Id.ToString(),
                IsSelected = c.Id == countryId?true:false
            }).OrderBy(c=>c.DisplayText).ToList();
            return countryComboboxDto;
        }

        public List<ComboboxItemDto> StateComboBoxDto(int? countryId,int? stateId)
        {
            List<ComboboxItemDto> countryComboboxDto = _stateRepository.GetAll().Where(c=>c.CountryId==countryId).Select(c => new ComboboxItemDto
            {
                DisplayText = c.StateName,
                Value = c.Id.ToString(),
                IsSelected =c.Id==stateId?true:false
            }).OrderBy(c => c.DisplayText).ToList();
            return countryComboboxDto;
        }

        public List<ComboboxItemDto> CityComboBoxDto(int? stateId,int? cityId)
        {
            List<ComboboxItemDto> countryComboboxDto = _cityRepository.GetAll().Where(c=>c.StateId==stateId).Select(c => new ComboboxItemDto
            {
                DisplayText = c.CityName,
                Value = c.Id.ToString(),
                IsSelected =c.Id==cityId
            }).OrderBy(c => c.DisplayText).ToList();
            return countryComboboxDto;
        }
        #endregion

        #region ProductCombobox
        public List<ComboboxItemDto> ProductComboboxDto(int?[] ProductIds)
        {
            List<ComboboxItemDto> productComboboxDto;
            if (ProductIds != null)
            {
                productComboboxDto = _productRepository.GetAll().Select(c => new ComboboxItemDto
                {
                    DisplayText = c.ProductName,
                    Value = c.Id.ToString(),
                    IsSelected = ProductIds.Contains(c.Id) ? true : false
                }).OrderBy(c => c.DisplayText).ToList();
            }
            else
            {
                productComboboxDto = _productRepository.GetAll().Select(c => new ComboboxItemDto
                {
                    DisplayText = c.ProductName,
                    Value = c.Id.ToString()
                }).OrderBy(c => c.DisplayText).ToList();
            }
            return productComboboxDto;
        }
        #endregion
    }
}
