using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Addresses
{
    public class StateListViewModel
    {
        public List<ComboboxItemDto> StateList { get; set; }

        public StateListViewModel(List<ComboboxItemDto> stateList)
        {
            StateList = stateList;
        }
    }
}
