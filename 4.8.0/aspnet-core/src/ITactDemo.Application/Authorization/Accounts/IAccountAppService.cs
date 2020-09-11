using System.Threading.Tasks;
using Abp.Application.Services;
using ITactDemo.Authorization.Accounts.Dto;

namespace ITactDemo.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
