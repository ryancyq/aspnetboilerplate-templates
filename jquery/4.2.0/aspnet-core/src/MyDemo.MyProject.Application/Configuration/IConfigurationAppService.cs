using System.Threading.Tasks;
using MyDemo.MyProject.Configuration.Dto;

namespace MyDemo.MyProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
