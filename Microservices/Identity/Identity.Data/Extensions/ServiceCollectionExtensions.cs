using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DbConnection"),
                    new MySqlServerVersion(new Version(configuration.GetConnectionString("ServerVersion")))));

            services.AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.SignIn.RequireConfirmedEmail = true;
                    opt.User.RequireUniqueEmail = true;
                    opt.Password.RequiredLength = 10;
                })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(2));
        }
    }
}