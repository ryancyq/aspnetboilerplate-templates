using Abp.Authorization;
using MyDemo.MyProject.Authorization.Roles;
using MyDemo.MyProject.Authorization.Users;

namespace MyDemo.MyProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
