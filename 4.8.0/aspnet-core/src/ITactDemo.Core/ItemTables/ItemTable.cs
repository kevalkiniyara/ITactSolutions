using Abp.Domain.Entities.Auditing;
using ITactDemo.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.ItemTables
{
    [Table("ItemCategory")]
    public class ItemTable:AuditedEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
