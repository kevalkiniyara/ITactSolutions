using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Products
{
    [Table("Product")]
    public class Product:AuditedEntity
    {
        public string ProductName { get; set; }
    }
}
