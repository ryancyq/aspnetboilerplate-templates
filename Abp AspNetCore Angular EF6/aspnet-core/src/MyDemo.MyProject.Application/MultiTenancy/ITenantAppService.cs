using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyDemo.MyProject.MultiTenancy.Dto;

namespace MyDemo.MyProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
