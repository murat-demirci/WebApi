using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;

namespace Persistance;
public static class PersistanceServiceExtension
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddTransient<IArabaRepository>(sp=> new ArabaRepository(configuration));

        return services;
    }
}
