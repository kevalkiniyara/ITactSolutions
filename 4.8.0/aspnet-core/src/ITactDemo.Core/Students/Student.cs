using Abp.Domain.Entities.Auditing;
using ITactDemo.Addresses;
using ITactDemo.StudentHobbies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Students
{
    [Table("Students")]
    public class Student: AuditedEntity
    {
        public const int MaxNameLength = 256;
        public const int MaxNumberLength = 10;

        [Required]
        [StringLength(MaxNameLength)]
        public string FirstName { get; set; }

        [StringLength(MaxNameLength)]
        public string LastName { get; set; }

        [StringLength(MaxNameLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxNumberLength)]
        public string PhoneNumber { get; set; }

        public StandardEnum Standard { get; set; }
        
        public DateTime BirthDate { get; set; }

        [ForeignKey("CountryId")]
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        [ForeignKey("StateId")]
        public int? StateId { get; set; }

        public virtual State State { get; set; }

        [ForeignKey("CityId")]
        public int? CityId { get; set; }

        public virtual City City { get; set; }

        public string Gender { get; set; }

        public ICollection<StudentHobby> StudentHobbies { get; set; }

        public string StudentImage { get; set; }


    }
}
