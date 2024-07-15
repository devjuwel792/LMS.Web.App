using LMS.Application;
using LMS.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.loC.Configuration;

public static class ServiceCollectionsExtension
{
    public static IServiceCollection AddIOCConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepository(configuration);
        services.AddApplicationService(configuration);
                                          
        return services;
    }

}
