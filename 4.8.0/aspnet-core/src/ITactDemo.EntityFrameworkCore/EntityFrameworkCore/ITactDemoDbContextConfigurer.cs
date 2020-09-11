using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ITactDemo.EntityFrameworkCore
{
    public static class ITactDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ITactDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ITactDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
