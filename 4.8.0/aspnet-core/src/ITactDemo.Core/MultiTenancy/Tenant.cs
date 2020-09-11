using Abp.MultiTenancy;
using ITactDemo.Authorization.Users;

namespace ITactDemo.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public string Address { get; set; }

        public TenantTypeEnum TenantType { get; set; }
        
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
