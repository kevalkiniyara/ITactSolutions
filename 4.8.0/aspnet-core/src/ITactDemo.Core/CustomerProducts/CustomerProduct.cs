using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITactDemo.Customers;
using ITactDemo.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.CustomerProducts
{
    [Table("CustomerProduct")]
    public class CustomerProduct: Entity
    {
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }

        public Product Product { get; set; }
    }

}
