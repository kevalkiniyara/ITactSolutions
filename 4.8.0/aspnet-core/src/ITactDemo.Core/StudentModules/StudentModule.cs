using Abp.Domain.Entities.Auditing;
using ITactDemo.Addresses;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.StudentModules
{
    [Table("StudentModule")]
    public class StudentModule: AuditedEntity
    {
        public string StudentName { get; set; }

        public string Gender { get; set; }

        public StandardEnum Standard { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int StateId { get; set; }

        public State State { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
        
    }
}
