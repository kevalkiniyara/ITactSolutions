using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITactDemo.Categories;
using ITactDemo.Items;
using ITactDemo.OrderItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Orders
{
    [Table("Orders")]
    public class Order: AuditedEntity
    {
        public const int MaxNameLength = 64;

        [Required]
        // [Display(Name ="OrderName",ResourceType =typeof(Resource))]
        public string OrderNumber { get; set; }

        [Required]
        // [Display(Name ="OrderDate",ResourceType =typeof(Resource))]
        public DateTime OrderDate { get; set; }

        [StringLength(MaxNameLength)]
        // [Display(Name ="Description",ResourceType =typeof(Resource))]
        public string Description { get; set; }

        [Required]
        //[Display(Name = "TotalAmount", ResourceType =typeof(Resource))]
        public decimal TotalAmount { get; set; }

        [ForeignKey("CategoryId")]
        // [Display(Name ="CategoryId",ResourceType =typeof(Resource))]
        public int? CategoryId { get; set; }

        //[Display(Name ="Category",ResourceType =typeof(Resource))]
        public virtual Category Category { get; set; }

        //[Display(Name ="OrderItems",ResourceType =typeof(Resource))]
        public ICollection<OrderItem> OrderItems { get; set; }

        public int ItemQuantity { get; set; }

    }
}
