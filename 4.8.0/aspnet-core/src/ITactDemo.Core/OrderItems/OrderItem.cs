using Abp.Domain.Entities;
using ITactDemo.Items;
using ITactDemo.ItemTables;
using ITactDemo.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITactDemo.OrderItems
{
    [Table("OrderItems")]
    public class OrderItem:Entity
    {
        [ForeignKey("OrderId")]
        // [Display(Name ="OrderId",ResourceType =typeof(Resource))]
        public int OrderId { get; set; }

        // [Display(Name ="Order",ResourceType =typeof(Resource))]
        public virtual Order Order { get; set; }

        [ForeignKey("ItemId")]
        //[Display(Name ="ItemId",ResourceType =typeof(Resource))]
        public int ItemId { get; set; }

        //[Display(Name ="Item",ResourceType =typeof(Resource))]
        public virtual ItemTable Item { get; set; }

        // [Display(Name ="Price",ResourceType =typeof(Resource))]
        public decimal Price { get; set; }
    }
}
