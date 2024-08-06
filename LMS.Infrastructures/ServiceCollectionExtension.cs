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
        //services.Configure<IdentityOptions>(options =>
        //{
        //    options.Password.RequiredLength = 7;
        //    options.Password.RequireDigit = false;
        //    options.Password.RequireLowercase = false;
        //    options.Password.RequireUppercase = false;
        //    options.Password.RequiredUniqueChars = 0;
        //});
        services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}