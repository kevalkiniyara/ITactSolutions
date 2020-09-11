using System.Collections.Generic;
using ITactDemo.Roles.Dto;

namespace ITactDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}