using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITactDemo.ItemTables.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITactDemo.ItemTables
{
    public class ItemTableAppService:ITactDemoAppServiceBase
    {
        private readonly IRepository<ItemTable> _itemTableRepository;

        public ItemTableAppService(IRepository<ItemTable> itemTableRepository)
        {
            _itemTableRepository = itemTableRepository;
        }
        
        public async Task<CreateOrUpdateItemTableDto> GetItemsForEdit(NullableIdDto input)
        {
            CreateOrUpdateItemTableDto createOrUpdateItemTableDto;
            if(input.Id.HasValue)
            {
                ItemTable itemTable = await _itemTableRepository.GetAll().FirstOrDefaultAsync(c => c.Id == input.Id);
                createOrUpdateItemTableDto = ObjectMapper.Map<CreateOrUpdateItemTableDto>(itemTable);
            }
            else
            {
                createOrUpdateItemTableDto = new CreateOrUpdateItemTableDto();
            }
            return createOrUpdateItemTableDto;
        }

        public async Task CreateOrupdateItems(CreateOrUpdateItemTableDto input)
        {
            if(input.Id ==0)
            {
               await CreateItems(input);
            }
        }

        public async Task CreateItems(CreateOrUpdateItemTableDto input)
        {
            try
            {
                ItemTable itemTable = ObjectMapper.Map<ItemTable>(input);
                await _itemTableRepository.InsertAsync(itemTable);
            }
            catch(Exception ex)
            {
                
            }
        }
        
    }
}
