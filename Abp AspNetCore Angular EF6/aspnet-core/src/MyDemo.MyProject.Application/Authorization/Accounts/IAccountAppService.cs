using System.Threading.Tasks;
using Abp.Application.Services;
using MyDemo.MyProject.Authorization.Accounts.Dto;

namespace MyDemo.MyProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
