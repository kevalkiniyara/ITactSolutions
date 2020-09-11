using Abp.Domain.Entities.Auditing;
using ITactDemo.StudentHobbies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Students
{
    [Table("Hobbies")]
    public class Hobby:AuditedEntity
    {
        public string HobbyName { get; set; }
    }
}
