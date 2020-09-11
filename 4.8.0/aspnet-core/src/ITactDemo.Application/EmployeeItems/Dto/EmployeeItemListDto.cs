using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITactDemo.EmployeeItems.Dto
{
    [AutoMapFrom(typeof(EmployeeItem))]
    public class EmployeeItemListDto:Entity
    {
        public int? EmployeeId { get; set; }

        public int? ItemId { get; set; }

    }
}
