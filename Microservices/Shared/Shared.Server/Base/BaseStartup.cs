using System.Reflection;
using Azure.Storage.Blobs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared.Server.Extensions;
using Shared.Services.Implementation.ErrorHandler;

namespace Shared.Server.Base
{
    public abstract class BaseStartup
    {
        protected BaseStartup(IWebHostEnvironment environment)
        {
            Environment = environment;
            var path = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.ContentRootPath)
                .AddJsonFile(path + "/../../Shared/Shared.Server/appsettings.json", false, true)
                .AddJsonFile(path + $"/../../Shared/Shared.Server/appsettings.{Environment.EnvironmentName}.json", true)
                .AddJsonFile(path + "/appsettings.json", false, true);
            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        protected IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        protected void ConfigureServices(IServiceCollection services, Assembly assembly)
        {
            services.AddControllers();

            services.AddMediatR(assembly);

            services.AddValidation(assembly);

            services.AddAutoMapper(assembly);

            // services.AddStackExchangeRedisCache(option =>
            // {
            //     option.Configuration = Configuration["Cache:Configuration"];
            //     option.InstanceName = Configuration["Cache:InstanceName"];
            // });

            services.AddGrpc(options => { options.EnableDetailedErrors = true; });

            AddDbContext(services);
            
            services.AddSingleton(
                new BlobServiceClient(Configuration.GetConnectionString("AzureBlob")).GetBlobContainerClient(
                    Configuration["AzureBlobContainer"]));

            services.AddImageConfigurations(Configuration);

            services.AddAuth(Configuration);

            services.AddEmailServer(Configuration);
            services.AddSmsServer(Configuration);

            services.AddEventBus(opt =>
            {
                opt.ConnectionString = Configuration["RabbitMQ:ConnectionString"];
                opt.SubscriptionPrefixId = Configuration["RabbitMQ:SubscriptionPrefixId"];
                opt.RegistrationAssemblies = new[] { assembly };
            });
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                ConfigureGrpcEndpoints(endpoints);
            });
        }

        protected abstract void AddDbContext(IServiceCollection services);
        protected abstract void ConfigureGrpcEndpoints(IEndpointRouteBuilder endpoints);
    }
}