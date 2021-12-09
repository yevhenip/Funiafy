using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot(new ConfigurationBuilder().AddJsonFile("ocelot.json").Build());

var app = builder.Build();
app.UseOcelot().Wait();
app.Run();