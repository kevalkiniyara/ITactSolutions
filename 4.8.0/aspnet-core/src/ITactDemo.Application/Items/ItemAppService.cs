using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITactDemo.Items.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITactDemo.Items
{
    public class ItemAppService:ITactDemoAppServiceBase
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemAppService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        //public async Task<CreateOrUpdateItemDto> GetItemForEdit(NullableIdDto input)
        //{
        //    CreateOrUpdateItemDto createOrUpdateItemDto;
        //    if (input.Id.HasValue)
        //    {
        //        Item item = await _itemRepository.GetAll().FirstOrDefaultAsync(c => c.Id == input.Id);
        //        createOrUpdateItemDto = ObjectMapper.Map<CreateOrUpdateItemDto>(item);
        //    }
        //    else
        //    {
        //        createOrUpdateItemDto = new CreateOrUpdateItemDto();
        //    }
        //    return createOrUpdateItemDto;
        //}
        //public async Task CreateOrupdateItem(CreateOrUpdateItemDto input)
        //{
        //    if (input.Id == 0)
        //    {
        //        await CreateItems(input);
        //    }

        //}

        //public async Task CreateItems(CreateOrUpdateItemDto input)
        //{
        //    try
        //    {
        //        Item itemTable = ObjectMapper.Map<Item>(input);
        //        await _itemRepository.InsertAsync(itemTable);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

    }
}
