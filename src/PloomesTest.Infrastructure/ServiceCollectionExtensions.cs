using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PloomesTest.Core.Repositories;
using PloomesTest.Core.Services;
using PloomesTest.Infrastructure.Data;
using PloomesTest.Infrastructure.Data.Repositories;

namespace PloomesTest.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<DataContext>(opt => _ = opt
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking))
                .AddScoped<IClientRepository, EFClientRepository>()
                .AddScoped<ClientService>();
        }
    }
}