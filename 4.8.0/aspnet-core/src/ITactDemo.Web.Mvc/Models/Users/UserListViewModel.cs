using System.Collections.Generic;
using ITactDemo.Roles.Dto;
using ITactDemo.Users.Dto;

namespace ITactDemo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
