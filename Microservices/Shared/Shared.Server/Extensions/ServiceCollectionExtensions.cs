using System.Reflection;
using System.Text;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.Server.EventBus;
using Shared.Server.Validation;
using Shared.Services.Implementation.Jwt;
using Shared.Services.Implementation.Senders;
using Shared.Services.Implementation.Settings;
using Shared.Services.Interfaces.Jwt;
using Shared.Services.Interfaces.Senders;
using Twilio.Clients;
using Twilio.Http;
using HttpClient = System.Net.Http.HttpClient;

namespace Shared.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEventBus(this IServiceCollection services, Action<EventBusSettings> options)
        {
            var busOptions = new EventBusSettings();

            options.Invoke(busOptions);

            services.AddSingleton(busOptions);
            services.AddSingleton(_ => RabbitHutch.CreateBus(busOptions.ConnectionString));
            services.AddSingleton<MicrosoftDiMessageDispatcher>();
            services.AddSingleton(sp =>
            {
                var subscriber = new AutoSubscriber(sp.GetRequiredService<IBus>(), busOptions.SubscriptionPrefixId)
                {
                    AutoSubscriberMessageDispatcher = sp.GetRequiredService<MicrosoftDiMessageDispatcher>()
                };

                return subscriber;
            });

            services.AddHostedService<EventBusInitializationBackgroundService>();
        }

        public static void AddValidation(this IServiceCollection services, Assembly validatorsAssembly)
        {
            AssemblyScanner.FindValidatorsInAssembly(validatorsAssembly)
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
        }

        public static void AddEmailServer(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<EmailSettings>();
            services.AddSingleton(emailConfig);

            services.AddScoped<IEmailSender, EmailSender>();
        }

        public static void AddSmsServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISmsSender, SmsSender>();
            services.AddSingleton<ITwilioRestClient>(new TwilioRestClient(
                configuration["Twilio:AccountSid"],
                configuration["Twilio:AuthToken"],
                httpClient: new SystemNetHttpClient(new HttpClient())));

            services.AddSingleton(new SmsNumberSender { From = configuration["Twilio:From"] });
        }

        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection("Jwt");
            services.Configure<JwtSettings>(jwtSection);
            var jwtSettings = jwtSection.Get<JwtSettings>();

            services.AddSingleton<IJwtService, JwtService>();

            services.AddAuthorization();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.SaveToken = true;

                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true
                };
            });
        }
        
        public static void AddImageConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var imageSettings = new ImageSettings();
            configuration.GetSection("ImageSettings").Bind(imageSettings);
            services.AddSingleton(imageSettings);
        }
    }
}