using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portify.Infrastructure.Data.Context;

namespace Portify.Infrastructure.Extensions;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PortifyDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }

