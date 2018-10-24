using Abp.Authorization.Users;
using Abp.Dependency;
using MyDemo.MyProject.Authorization.Users;
using MyDemo.MyProject.MultiTenancy;
using System.Threading.Tasks;

namespace MyDemo.MyProject.Authorization
{
  public class MyExternalAuthenticationSource : DefaultExternalAuthenticationSource<Tenant, User>, ITransientDependency
  {
    public override string Name
    {
      get { return "Mine"; }
    }

    public override Task<bool> TryAuthenticateAsync(string userNameOrEmailAddress, string plainPassword, Tenant tenant)
    {
        if (tenant == null ||
            !userNameOrEmailAddress.Contains("@"))
        {
            return Task.FromResult(false);
        }
        return Task.FromResult(true);
    }
  }
}
