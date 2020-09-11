using Abp.Application.Services.Dto;
using ITactDemo.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Orders
{
    public class CreateOrUpdateOrderViewModel
    {
        public CreateOrUpdateOrderDto Order;

        public List<ComboboxItemDto> CategoryList { get; set; }

        public List<ComboboxItemDto> ItemList { get; set; }

        public CreateOrUpdateOrderViewModel(CreateOrUpdateOrderDto createOrUpdateOrderDto,List<ComboboxItemDto> categoryList,List<ComboboxItemDto> itemList)
        {
            Order = createOrUpdateOrderDto;
            CategoryList = categoryList;
            ItemList = itemList;
        }
    }
}
