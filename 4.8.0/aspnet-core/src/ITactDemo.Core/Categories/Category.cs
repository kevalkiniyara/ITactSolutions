using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Categories
{
    [Table("Category")]
    public class Category:AuditedEntity
    {
        public string Name { get; set; }

    }
}
