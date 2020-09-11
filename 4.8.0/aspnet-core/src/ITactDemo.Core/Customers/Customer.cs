using Abp.Domain.Entities.Auditing;
using ITactDemo.Addresses;
using ITactDemo.CustomerProducts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Customers
{
    [Table("Customer")]
    public class Customer:AuditedEntity
    {
        public const int CustomerNameLength= 32;
        public const int CustomerPhoneNumberength= 10;
        
        [StringLength(CustomerNameLength)]
        public string FirstName { get; set; }

        [StringLength(CustomerNameLength)]
        public string LastName { get; set; }

        [StringLength(CustomerNameLength)]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(CustomerPhoneNumberength)]
        public string PhoneNumber { get; set; }

        public CustomerEnumType AccountType { get; set; }

        public string Gender { get; set; }

        public string CustomerImage { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        [ForeignKey("StateId")]
        public int StateId { get; set; }

        public State State { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

        public List<CustomerProduct> CustomerProducts { get; set; }

    }
}
