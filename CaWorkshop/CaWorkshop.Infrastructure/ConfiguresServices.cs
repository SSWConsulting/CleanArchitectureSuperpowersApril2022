using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Application.Common.Services.Identity;
using CaWorkshop.Infrastructure.Data;
using CaWorkshop.Infrastructure.Identity;
using CaWorkshop.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CaWorkshop.Infrastructure;

public static class ConfiguresServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
            options
                .UseSqlServer(connectionString)
                .AddInterceptors(
                    ActivatorUtilities.CreateInstance<AuditEntitiesSaveChangesInterceptor>(sp)));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddTransient<ApplicationDbContextInitialiser>();

        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}
