using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;

namespace ITactDemo.MultiTenancy.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantDto : EntityDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBase.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string Name { get; set; }        
        
        public bool IsActive {get; set;}

        public string Address { get; set; }

        public TenantTypeEnum TenantType { get; set; }
    }
}
