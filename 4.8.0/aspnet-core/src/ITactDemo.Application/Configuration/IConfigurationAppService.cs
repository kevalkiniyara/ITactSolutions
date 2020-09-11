using System.Threading.Tasks;
using ITactDemo.Configuration.Dto;

namespace ITactDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
