using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITactDemo.Addresses;
using ITactDemo.CustomerProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.Customers.Dto
{
    [AutoMapFrom(typeof(Customer))]
    public class CustomerListDto:EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public CustomerEnumType AccountType { get; set; }

        public string Gender { get; set; }

        public string CustomerImage { get; set; }

        public Country Country { get; set; }

        public State State { get; set; }

        public City City { get; set; }

        public List<CustomerProduct> CustomerProducts { get; set; }
    }
}
