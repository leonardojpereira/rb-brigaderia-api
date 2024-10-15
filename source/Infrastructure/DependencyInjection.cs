using Project.Application.Common.Interfaces;
using Project.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Project.Infrastructure.Data.Respositories;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Infrastructure.Authentication;
using Project.Domain.Interfaces.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());


                options.UseSqlServer(connectionString); 


        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddScoped<ITokenService, TokenService>();

        services.AddAuthorizationBuilder();

        services.AddSingleton(TimeProvider.System);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Repository") && t.IsClass && !t.IsAbstract)
                .ToList();

            foreach (var implementationType in types)
            {
                var interfaceType = implementationType.GetInterface($"I{implementationType.Name}");

                if (interfaceType != null)
                {
                    services.AddTransient(interfaceType, implementationType);
                }
            }
        }

        return services;
    }

}
