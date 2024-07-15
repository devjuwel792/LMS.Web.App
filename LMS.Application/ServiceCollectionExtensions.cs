using LMS.Application.Repositories.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.Application;

public static class ServiceCollectionExtensions
{
   public static  void AddApplicationService(this IServiceCollection services,IConfiguration configuration)
    {
        services.Scan(scan => scan.FromAssemblyOf<IApplication>()
      .AddClasses(classes => classes.AssignableTo<IApplication>())
      .AddClasses(x => x.AssignableTo(typeof(IBaseRepository<,,>)))
      .AsSelfWithInterfaces()
      .WithScopedLifetime());


        services.AddAutoMapper(x => {
            x.AddMaps(typeof(IApplication).Assembly);

        });
    }
    
}
