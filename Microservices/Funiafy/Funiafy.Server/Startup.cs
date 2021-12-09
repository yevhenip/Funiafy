using Funiafy.Business.MapperProfiles;
using Funiafy.Data.Extensions;
using Shared.Server.Base;

namespace Funiafy.Server
{
    public class Startup : BaseStartup
    {
        public Startup(IWebHostEnvironment environment) : base(environment)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services, typeof(FuniafyProfile).Assembly);
        }

        protected override void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext(Configuration);
        }

        protected override void ConfigureGrpcEndpoints(IEndpointRouteBuilder services)
        {
        }
    }
}