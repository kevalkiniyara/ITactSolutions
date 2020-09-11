using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using ITactDemo.Authorization;
using ITactDemo.Controllers;
using ITactDemo.MultiTenancy;
using ITactDemo.MultiTenancy.Dto;

namespace ITactDemo.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : ITactDemoControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _tenantAppService.GetAll(new PagedTenantResultRequestDto { MaxResultCount = int.MaxValue }); // Paging not implemented yet
            return View(output);
        }

        public async Task<ActionResult> EditTenantModal(int tenantId)
        {
            var tenantDto = await _tenantAppService.Get(new EntityDto(tenantId));
            return View("_EditTenantModal", tenantDto);
        }

        public async Task<ActionResult> EditTenantModel(int id)
        {
            var tenantDto = await _tenantAppService.Get(new EntityDto(id));
            return View(tenantDto);

        }
    }
}
