using System.Threading.Tasks;
using Abp.Application.Services;
using MyDemo.MyProject.Sessions.Dto;

namespace MyDemo.MyProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
