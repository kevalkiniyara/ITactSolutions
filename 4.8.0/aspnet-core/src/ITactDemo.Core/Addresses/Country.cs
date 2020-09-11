using Abp.Domain.Entities;
using ITactDemo.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Addresses
{
    [Table("Country")]
    public class Country: Entity
    {
        public string CountryName { get; set; }
    }
}
