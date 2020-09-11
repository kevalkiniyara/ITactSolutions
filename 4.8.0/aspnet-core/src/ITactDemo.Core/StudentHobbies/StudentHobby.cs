using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.StudentHobbies
{
    [Table("StudentHobbies")]
    public class StudentHobby:Entity
    {
        public virtual Student Student { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        public virtual Hobby Hobby { get; set; }

        [ForeignKey("HobbyId")]
        public int HobbyId { get; set; }
    }
}
