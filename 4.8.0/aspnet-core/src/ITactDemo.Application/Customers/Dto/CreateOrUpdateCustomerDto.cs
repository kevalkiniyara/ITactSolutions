using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITactDemo.Customers.Dto
{
    [AutoMap(typeof(Customer))]
    public class CreateOrUpdateCustomerDto:EntityDto
    {
        [StringLength(Customer.CustomerNameLength)]
        public string FirstName { get; set; }

        [StringLength(Customer.CustomerNameLength)]
        public string LastName { get; set; }

        [StringLength(Customer.CustomerNameLength)]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(Customer.CustomerPhoneNumberength)]
        public string PhoneNumber { get; set; }

        public CustomerEnumType AccountType { get; set; }

        public string Gender { get; set; }

        public string CustomerImage { get; set; }

        public string CustomerImagePic { get; set; }

        public int? CountryId { get; set; }

        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public int?[] ProductIds { get; set; }

    }
}
