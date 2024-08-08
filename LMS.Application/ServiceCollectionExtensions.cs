using LMS.Application.Helpers;
using LMS.Application.Repositories;
using LMS.Application.Repositories.Base;
using LMS.Application.Service;
using LMS.Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Scan(scan => scan.FromAssemblyOf<IApplication>()
      .AddClasses(classes => classes.AssignableTo<IApplication>())
      .AddClasses(x => x.AssignableTo(typeof(IBaseRepository<,,>)))
      .AsSelfWithInterfaces()
      .WithScopedLifetime());

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
        services.AddScoped<IUserService, UserService>();

        services.AddAutoMapper(x =>
        {
            x.AddMaps(typeof(IApplication).Assembly);
        });
    }
}