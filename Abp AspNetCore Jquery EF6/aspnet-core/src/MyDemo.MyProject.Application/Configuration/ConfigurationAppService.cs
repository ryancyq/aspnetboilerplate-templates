using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyDemo.MyProject.Configuration.Dto;

namespace MyDemo.MyProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
