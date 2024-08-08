using LMS.Domain.Model.IdentityModels;
using LMS.Domain.Model.Mail;
using LMS.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static LMS.Infrastructure.Constants;

namespace LMS.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure DbContext
        services.AddDbContext<ApplicationDbContext>((s, builder) =>
        {
            builder.UseSqlServer(configuration.GetConnectionString(ApplicationConstants.DefaultConnection));
        }, ServiceLifetime.Scoped);

        // Configure EmailSetting
        //services.Configure<EmailSetting>(configuration.GetSection("emailSettings"));
      

        // Configure Identity
        services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddEntityFrameworkStores<ApplicationDbContext>();
        // Configure Identity login Path
        services.ConfigureApplicationCookie(config =>
                {
                    config.LoginPath = "/login";
                });

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 4;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredUniqueChars = 1;
        });

        return services;
    }
}