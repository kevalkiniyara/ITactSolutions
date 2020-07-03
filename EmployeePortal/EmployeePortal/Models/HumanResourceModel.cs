using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Models
{
    public class HumanResourceModel
    {
        [Key]
        public int HrId { get; set; }

        public string HrName { get; set; }

        public string HrAddress { get; set; }

        public DepartmentModel DepartmentId { get; set; }
    }
}
