using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITactDemo.Categories;
using ITactDemo.Grid;
using ITactDemo.Grid.Helper;
using ITactDemo.Items;
using ITactDemo.ItemTables;
using ITactDemo.OrderItems;
using ITactDemo.Orders.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using ITactDemo.OrderItems.Dto;
using Microsoft.ApplicationBlocks.Data;
using ITactDemo.Items.Dto;

namespace ITactDemo.Orders
{
    public class OrderAppService:ITactDemoAppServiceBase
    {
        
        #region Declaration
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<ItemTable> _itemRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IConfiguration _configuration;
       
        #endregion

        #region Constructor
        public OrderAppService(
            IRepository<Order> orderRepository,
            IRepository<Category> categoryRepository,
            IRepository<ItemTable> itemRepository,
            IRepository<OrderItem> orderItemRepository,IConfiguration configuration
            )
        {
            _orderRepository = orderRepository;
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _orderItemRepository = orderItemRepository;
            _configuration = configuration;
        }
        #endregion

        #region GetOrders
        public GridOutputDto<OrderListDto> GetOrderAsyc(GridSettings gridInput)
        {
            try
            {
                IQueryable<Order> query = _orderRepository.GetAll().Include(c => c.OrderItems).ThenInclude(c=>c.Item).GridCommonSettings(gridInput, out int count).AsQueryable();
                GridOutputDto<OrderListDto> gridOutput = new GridOutputDto<OrderListDto>()
                {
                    Page = gridInput.PageIndex,
                    Total = (int)Math.Ceiling((double)count/gridInput.PageSize),
                    Records = count,
                    Rows = GetOrder(query)
                };
                return gridOutput;
            }
            catch(Exception ex)
            {
                GridOutputDto<OrderListDto> gridOutput = new GridOutputDto<OrderListDto>()
                {
                };
                return gridOutput;
            }
        }
        public List<OrderListDto> GetOrder(IQueryable<Order> order)
        {   
            List<OrderListDto> orderListDto = order.Select(c => new OrderListDto
            {
                Id=c.Id,
                OrderNumber=c.OrderNumber,
                OrderDate=c.OrderDate,
                Description=c.Description,
                TotalAmount=c.TotalAmount
            }).ToList();
            return orderListDto;
        }
        
        public List<OrderItemListDto> GetOrderItem(int? id)
        {
            List<OrderItem> orders = _orderItemRepository.GetAll().Include(c => c.Item).Where(c=>c.OrderId==id).ToList();
            List<OrderItemListDto> orderItemListDtos = orders.Select(c => new OrderItemListDto
            {
                ItemName =c.Item.Name,
                Price = c.Price
            }).ToList();
            List<OrderItemListDto> itemListDto = ObjectMapper.Map<List<OrderItemListDto>>(orders);
            
            return itemListDto;
        }
        #endregion

        #region Crud-Methods For Order
        public async Task<CreateOrUpdateOrderDto> GetOrderEdit(NullableIdDto input)
        {
            CreateOrUpdateOrderDto createOrUpdateOrderDto;
            if(input.Id.HasValue)
            {
                Order order = await _orderRepository.GetAll().Include(c=>c.OrderItems).FirstOrDefaultAsync(c =>c.Id==input.Id);
                createOrUpdateOrderDto = ObjectMapper.Map<CreateOrUpdateOrderDto>(order);
            }
            else
            {
                createOrUpdateOrderDto = new CreateOrUpdateOrderDto();
            }
            return createOrUpdateOrderDto;
        }
        public async Task CreateOrupdateOrder(CreateOrUpdateOrderDto input)
        {
            if(input.Id==0)
            {
                await CreateOrder(input);
            }
            else
            {
                await UpdateOrder(input);
            }
        }
        public async Task CreateOrder(CreateOrUpdateOrderDto input)
        {
            try
            {
                Order order = ObjectMapper.Map<Order>(input);
                await _orderRepository.InsertAsync(order);
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(L("CRUD.CreateDependency"));
            }
        }

        public async Task UpdateOrder(CreateOrUpdateOrderDto input)
        {
            try
            {
                Order order = await _orderRepository.GetAll().Include(c => c.OrderItems).FirstOrDefaultAsync(c => c.Id == input.Id);
                if (order != null)
                {
                    foreach (var orderItem in order.OrderItems)
                    {
                        await _orderItemRepository.DeleteAsync(orderItem);
                    }
                }
                ObjectMapper.Map(input, order);
                await _orderRepository.UpdateAsync(order);
            }
            catch(Exception ex)
            {
                throw new UserFriendlyException(L("CRUD.UpdateDependency"));
            }
        }
        public async Task Deleteorder(EntityDto input)
        {
            Order order = await _orderRepository.GetAll().Include(c=>c.OrderItems).FirstOrDefaultAsync(c => c.Id == input.Id);
            if(order!=null)
            {
                foreach(var orderItem in order.OrderItems)
                {
                    await _orderItemRepository.DeleteAsync(orderItem);
                }
                await _orderRepository.DeleteAsync(order);
            }
            try
            {
                await CurrentUnitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("CRUD.DeleteDependency"));
            }
        }
        #endregion

        #region Item-ComboBox
        public List<ComboboxItemDto> CategoryComboBoxDto(int? categoryId)
        {
            List<ComboboxItemDto> categoryComboboxDto = _categoryRepository.GetAll().Select(c => new ComboboxItemDto
            {
                DisplayText = c.Name,
                Value = c.Id.ToString(),
                IsSelected = c.Id == categoryId ? true : false
            }).ToList();
            return categoryComboboxDto;
        }

        public List<ComboboxItemDto> ItemCombobox(int? categoryId,int? itemId)
        {
            List<ComboboxItemDto> itemComboboxDto = _itemRepository.GetAll().Where(C=>C.CategoryId==categoryId).Select(c => new ComboboxItemDto
            {
                DisplayText = c.Name,
                Value = c.Id.ToString(),
                IsSelected =c.Id==itemId? true : false
            }).ToList();
            return itemComboboxDto;
        }

        public decimal GetItemPrice(int?itemId)
        {
            decimal amount = _itemRepository.GetAll().FirstOrDefault(c => c.Id == itemId).Price;
            return amount;
        }

        public string GetItemImage(int? itemId)
        {
            ItemTable item = _itemRepository.GetAll().FirstOrDefault(c => c.Id == itemId);
            string image = !string.IsNullOrEmpty(item.Image) ? Path.Combine(AppConsts.UploadFolderPathitem, item.Image) : "";
            return image;
        }
        #endregion

        #region CreateStoreProcedure
        public void CreateJsonOrder(CreateOrUpdateOrderDto input)
        {
            try
            {
                var connection = _configuration.GetConnectionString("Default");
                SqlConnection sqlConnection = new SqlConnection(connection);

                sqlConnection.Open();
                
                var JsonValue = JsonConvert.SerializeObject(input.OrderItems);
                
                SqlHelper.ExecuteNonQuery(sqlConnection,"SP_Insert_Order1", 
                                                           new SqlParameter("@OrderNumber", input.OrderNumber),
                                                           new SqlParameter("@OrderDate", input.OrderDate),
                                                           new SqlParameter("@Description", input.Description),
                                                           new SqlParameter("@TotalAmount", input.TotalAmount),
                                                           new SqlParameter("@OrderItems", JsonValue));
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public List<OrderListDto> GetOrderGraph()
        {
            var order = _orderRepository.GetAll().Include(c=>c.OrderItems).ThenInclude(c=>c.Item).ToList();
            var orderList = order.Select(c => new OrderListDto
            {
                OrderNumber=c.OrderNumber,
                Item = c.OrderItems.Select(d=>d.ItemId).Count()
            }).ToList();
            return orderList;
        }

        public List<ItemListDto> GetItemGraph()
        {
            var item = _itemRepository.GetAll().ToList();
            var itemList = item.Select(d => new ItemListDto
            {
                Name = d.Name,
                Price = d.Price
            }).ToList();
            return itemList;
        }
        public List<OrderListDto> GetOrderData(string orderNumber)
        {

            var orderId = _orderRepository.GetAll().Where(c => c.OrderNumber == orderNumber).Select(c => c.Id).First();
            var order = _orderRepository.GetAll().Include(c => c.OrderItems)
                .ThenInclude(c => c.Item).Where(c => c.Id == orderId).ToList();
            var orderList = order.Select(c => new OrderListDto
            {

                //ItemName = c.OrderItems.Select(d => d.Item.Name),
                //Price = c.OrderItems.Select(e => e.Price)
            }).ToList();
            return orderList;
        }

        public List<OrderItemListDto> GetItemData(string orderNumber)
        {
            var orderId = _orderRepository.GetAll().Where(c => c.OrderNumber == orderNumber).Select(c => c.Id).First();
            List<OrderItem> orders = _orderItemRepository.GetAll().Include(c => c.Item).Where(c => c.OrderId == orderId).ToList();
            List<OrderItemListDto> orderItemListDtos = orders.Select(c => new OrderItemListDto
            {
                ItemName = c.Item.Name,
                Price = c.Price
            }).ToList();
           
            return orderItemListDtos;
        }

    }
}
