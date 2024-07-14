using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;
public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddMapster();
        TypeAdapterConfig.GlobalSettings.Default.MapToConstructor(true);
        return services;
    }
}
