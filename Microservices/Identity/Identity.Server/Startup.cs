using Identity.Business.MapperProfiles;
using Identity.Data.Extensions;
using Shared.Server.Base;
using Shared.Services.Implementation.Settings;

namespace Identity.Server
{
    public class Startup : BaseStartup
    {
        public Startup(IWebHostEnvironment environment) : base(environment)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services, typeof(IdentityProfile).Assembly);

            services.AddSingleton(new EmailTemplates());
        }

        protected override void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext(Configuration);
        }

        protected override void ConfigureGrpcEndpoints(IEndpointRouteBuilder endpoints)
        {
        }
    }
}