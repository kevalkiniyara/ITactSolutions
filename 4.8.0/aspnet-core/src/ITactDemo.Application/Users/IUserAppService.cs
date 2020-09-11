using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITactDemo.Roles.Dto;
using ITactDemo.Users.Dto;

namespace ITactDemo.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
