using Abp.Domain.Entities;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Addresses
{
    [Table("State")]
    public class State:Entity
    {
        public string StateName { get; set; }

        public virtual Country Country { get; set; }

        [ForeignKey("CountryId")]
        public int CountryId { get; set; }

    }
}
