using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITactDemo.Web.Models.Hobbies
{
    public class HobbyListViewModel
    {
        public List<ComboboxItemDto> HobbyList { get; set; }

        public HobbyListViewModel(List<ComboboxItemDto> hobbyList)
        {
            HobbyList = hobbyList;
        }
    }
}
