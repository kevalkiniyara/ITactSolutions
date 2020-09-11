using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ITactDemo.Configuration.Dto;

namespace ITactDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ITactDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
