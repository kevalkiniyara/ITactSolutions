using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITactDemo.Controllers;
using ITactDemo.Grid;
using ITactDemo.Items;
using ITactDemo.ItemTables;
using ITactDemo.OrderItems;
using ITactDemo.Orders;
using ITactDemo.Orders.Dto;
using ITactDemo.Web.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ITactDemo.Web.Mvc.Controllers
{
    public class OrdersController : ITactDemoControllerBase
    {
        #region Declaration
        private readonly OrderAppService _orderAppService;
        #endregion

        public OrdersController(OrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetOrder(GridSettings gridSettings)
        {
            GridOutputDto<OrderListDto> order = _orderAppService.GetOrderAsyc(gridSettings);
            return Json(order);
        }

        public JsonResult GetOrderItems(int? id)
        {   
            var result = _orderAppService.GetOrderItem(id);
            return Json(new
            {
                page = 1,
                total = 10,
                records = result.Count,
                rows = (from x in result select new
                        {
                            x.ItemName,
                            x.Price
                })
            });
        }

        public async Task<ActionResult> CreateOrUpdateOrder(int?id)
        {
            CreateOrUpdateOrderDto createOrUpdateOrder = await _orderAppService.GetOrderEdit(new NullableIdDto { Id = id });
            if(id==null)
            {
                createOrUpdateOrder.OrderDate = DateTime.Now.Date;
            }
            List<ComboboxItemDto> categoryComboBox = _orderAppService.CategoryComboBoxDto(createOrUpdateOrder.CategoryId);
            List<ComboboxItemDto> itemComboboxDto= _orderAppService.ItemCombobox(null,null);
            CreateOrUpdateOrderViewModel createOrUpdateOrderViewModel = new CreateOrUpdateOrderViewModel(createOrUpdateOrder,categoryComboBox,itemComboboxDto);
            return View(createOrUpdateOrderViewModel);
        }
        
        public ActionResult ItemGraph()
        {
            return View();
        }

        public ActionResult GetItemData()
        {
            var order = _orderAppService.GetItemGraph();
            return Json(order);
        }

        public ActionResult OrderGraph()
        {
            return View();
        }

        public ActionResult GetOrderData()
        {
            var order = _orderAppService.GetOrderGraph();
            return Json(order);
        }

        public ActionResult GetOrderValue(string orderNumber)
        {
            var result = _orderAppService.GetItemData(orderNumber);
            return Json(new
            {
                page = 1,
                total = 10,
                records = result.Count,
                rows = (from x in result
                        select new
                        {
                            x.ItemName,
                            x.Price
                        })
            });
        }

        public ActionResult GetGridToGraph()
        {
            return View();
        }
    }
}