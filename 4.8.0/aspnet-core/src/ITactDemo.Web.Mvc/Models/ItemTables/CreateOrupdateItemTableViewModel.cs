using ITactDemo.ItemTables.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.ItemTables
{
    public class CreateOrupdateItemTableViewModel
    {
        public CreateOrUpdateItemTableDto ItemTables;

        public CreateOrupdateItemTableViewModel(CreateOrUpdateItemTableDto itemTable)
        {
            ItemTables = itemTable;
        }
        
    }
}
