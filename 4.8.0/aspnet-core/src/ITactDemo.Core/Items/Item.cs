using Abp.Domain.Entities.Auditing;
using ITactDemo.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.Items
{
    [Table("Item")]
    public class Item:AuditedEntity
    {
        //[Display(Name ="Name",ResourceType =typeof(Resource))]
        public string Name { get; set; }

        //[Display(Name = "Price", ResourceType = typeof(Resource))]
        public decimal Price { get; set; }

        [ForeignKey("CategoryId")]
        //[Display(Name = "CategoryId", ResourceType = typeof(Resource))]
        public int CategoryId { get; set; }

        //[Display(Name = "Category", ResourceType = typeof(Resource))]
        public Category Category { get; set; }

        public string ItemImage { get; set; }


    }
}
