using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITactDemo.MultiTenancy.Dto;

namespace ITactDemo.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

