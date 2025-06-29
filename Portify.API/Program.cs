using Portify.API;
using Portify.API.extensions;
using Portify.Persistence.extensions;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Portify.API.Startup;
using Portify.Infrastructure.Configuration.Settings;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddPersistenceServices(builder.Configuration);

// Configure services using ServiceConfiguration
ServiceConfiguration.ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
