using LMS.Domain.Model.IdentityModels;
using LMS.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LMS.Infrastructure.Constants;

namespace LMS.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>((s, builder) =>
        {
            builder.UseSqlServer(configuration.GetConnectionString(ApplicationConstants.DefaultConnection));
        }, ServiceLifetime.Scoped);

        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)

     .AddRoles<IdentityRole>()
     .AddEntityFrameworkStores<ApplicationDbContext>();
        return services;
    }
}