using Abp.Authorization;
using ITactDemo.Authorization.Roles;
using ITactDemo.Authorization.Users;

namespace ITactDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
