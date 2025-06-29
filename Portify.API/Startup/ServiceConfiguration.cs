using Portify.Application.Interfaces;
using Portify.Domain.Services;
using Portify.Infrastructure.Configuration.Settings;

namespace Portify.API.Startup;

public class ServiceConfiguration
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            ConfigureDevelopmentServices(services, configuration);
        }
        else if (environment.IsProduction())
        {
            ConfigureProductionServices(services, configuration);
        }

        // Common services for all environments
        services.AddControllers();
        // Add other shared services here
        services.AddScoped<IJwtService, JwtService>();

    }

    private static void ConfigureDevelopmentServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<GitHubOAuthConfig>().Configure(options => configuration.GetSection(nameof(GitHubOAuthConfig)).Bind(options));
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
    }

    private static void ConfigureProductionServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<GitHubOAuthConfig>().Configure(options => configuration.GetSection(nameof(GitHubOAuthConfig)).Bind(options));
    }
}
