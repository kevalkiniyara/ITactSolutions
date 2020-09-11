using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using ITactDemo.Employees;
using ITactDemo.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.EmployeeItems
{
    [Table("EmployeeItem")]
    public class EmployeeItem: Entity
    {
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public int ItemId { get; set; }

        public  virtual Item Item { get; set; }

        public decimal Price { get; set; }

    }
}
