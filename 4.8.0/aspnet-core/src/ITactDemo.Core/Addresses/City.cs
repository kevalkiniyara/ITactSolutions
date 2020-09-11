using Abp.Domain.Entities;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Addresses
{
    [Table("City")]
    public class City:Entity
    {
        public string CityName { get; set; }

        public virtual State States { get; set; }

        [ForeignKey("StateId")]
        public int StateId { get; set; }

    }
}
