using LMS.Domain.Model.IdentityModels;
using LMS.Domain.Model.Mail;
using LMS.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
        //services.Configure<EmailSetting>(configuration.GetSection("emailSettings").Value);


        // Configure Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        // AddDefaultTokenProviders()  for email Confirmetion 

     
        services.ConfigureApplicationCookie(config =>
                {
                    config.LoginPath = "/login"; // Modify this path if necessary
                    config.AccessDeniedPath = "/Account/AccessDenied"; // Modify this path if necessary
                    
                });

        services.Configure<IdentityOptions>(options =>
        {   
            // password configure
            options.Password.RequiredLength = 4;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequireNonAlphanumeric = false;

            // Email Confirmation
            options.SignIn.RequireConfirmedEmail = true;

            // Account lockout if user input invalid password        
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 3;
           

            

        });
      

        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromMinutes(5);
        });

        return services;
    }
}