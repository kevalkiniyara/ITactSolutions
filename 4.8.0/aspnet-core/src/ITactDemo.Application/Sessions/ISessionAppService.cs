using System.Threading.Tasks;
using Abp.Application.Services;
using ITactDemo.Sessions.Dto;

namespace ITactDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
