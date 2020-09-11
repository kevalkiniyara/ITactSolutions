using Abp.Domain.Entities.Auditing;
using ITactDemo.Addresses;
using ITactDemo.Categories;
using ITactDemo.EmployeeHobbies;
using ITactDemo.EmployeeItems;
using ITactDemo.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Employees
{
    [Table("Employee")]
    public class Employee:AuditedEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public EmployeeProfessionEnum Profession { get; set; }

        public string Gender { get; set; }

        public string EmployeeImage { get; set; }

        [ForeignKey("CountryId")]
        public int? CountryId { get; set; }

        public Country Country { get; set; }

        [ForeignKey("StateId")]
        public int? StateId { get; set; }

        public State State { get; set; }

        [ForeignKey("CityId")]
        public int? CityId { get; set; }

        public City City { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey("ItemId")]
        public int? ItemId { get; set; }

        public Item Item { get; set; }

        public ICollection<EmployeeHobby> EmployeeHobbies { get; set; }

        public ICollection<EmployeeItem> EmployeeItems { get; set; }

        public decimal Price { get; set; }
        
    }
}
