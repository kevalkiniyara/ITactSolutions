using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ITactDemo.Configuration;
using ITactDemo.Web;

namespace ITactDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ITactDemoDbContextFactory : IDesignTimeDbContextFactory<ITactDemoDbContext>
    {
        public ITactDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ITactDemoDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ITactDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ITactDemoConsts.ConnectionStringName));

            return new ITactDemoDbContext(builder.Options);
        }
    }
}
