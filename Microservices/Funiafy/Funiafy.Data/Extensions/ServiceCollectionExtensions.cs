using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Funiafy.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FuniafyDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DbConnection"),
                    new MySqlServerVersion(new Version(configuration.GetConnectionString("ServerVersion")))));
        }
    }
}