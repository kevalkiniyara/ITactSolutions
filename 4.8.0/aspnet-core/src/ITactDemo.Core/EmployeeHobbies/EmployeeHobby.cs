using Abp.Domain.Entities;
using ITactDemo.Employees;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.EmployeeHobbies
{
    [Table("EmployeeHobby")]
    public class EmployeeHobby:Entity
    {
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int? HobbyId { get; set; }

        public virtual Hobby Hobby { get; set; }


    }
}
