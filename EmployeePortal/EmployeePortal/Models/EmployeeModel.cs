using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        [MinLength(10,ErrorMessage ="Please Enter the Valid Address")]
        [MaxLength(50,ErrorMessage ="Please enter the Valid Address")]
        public string EmployeeAddress { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [Range(1,10)]
        public string MobileNumber { get; set; }
    }
}
