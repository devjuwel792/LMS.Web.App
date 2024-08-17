using AutoMapper;
using LMS.Application.Service;
using LMS.Application.ViewModel.IdentityModelViewModel;
using LMS.Domain.Model.IdentityModels;
using LMS.Domain.Model.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
namespace LMS.Application.Repositories;

public class AccountRepository(UserManager<ApplicationUser> userManager, IMapper mapper, SignInManager<ApplicationUser> signInManager, IUserService userService, IEmailService emailService, IConfiguration configuration) : IAccountRepository
{
    private readonly UserManager<ApplicationUser> userManager = userManager;

    public async Task<IEnumerable<ApplicationUserVm>> GetAllUserAsync()
    {
        var data = await userManager.Users.ToListAsync();
        var user = mapper.Map<IEnumerable<ApplicationUserVm>>(data);
        return user;
    }
    public async Task<ApplicationUser> GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> CreateUserAsync(SignUpVm entity)
    {
        var user = mapper.Map<ApplicationUser>(entity);
        user.UserName = entity.Email;
        //var user = new ApplicationUser()
        //{
        //    Email = entity.Email,
        //    UserName = entity.Email,
        //    Name = entity.Name,
        //};
        var result = await userManager.CreateAsync(user, entity.Password);
        if (result.Succeeded)
        {
            await GenerateEmailConfirmtionTokenAsync(user);

        }
        return result;
    }

    public async Task GenerateEmailConfirmtionTokenAsync(ApplicationUser user)
    {
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        if (!string.IsNullOrEmpty(token))
        {
            await SendEmailConfirmationEmail(user, token);
        }
    }
    public async Task<SignInResult> PasswordSignInAsync(LoginVm data)
    {
        //var user = mapper.Map<ApplicationUser>(data);
        var result = await signInManager.PasswordSignInAsync(data.Email, data.Password, data.RememberMe, true); //lockout = ture

        return result;
    }





    public async Task SignOutAsync()
    {
        await signInManager.SignOutAsync();
    }
    public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordVm data)
    {
        var userId = userService.GetUserId();

        var user = await userManager.FindByIdAsync(userId);
        return await userManager.ChangePasswordAsync(user, data.CurrentPassword, data.NewPassword);
    }
    public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
    {

        token = token.Replace(" ", "+");

        var user = await userManager.FindByIdAsync(uid);
        var result = await userManager.ConfirmEmailAsync(user, token);

        return result;
    }
    private async Task SendEmailConfirmationEmail(ApplicationUser user, string token)
    {
        try
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "HtmlTemplate", "EmailConfirm.html");
            string htmlTemplate = File.ReadAllText(filePath);

            string? appDomain = configuration.GetSection("Application:AppDomain").Value;
            string? confirmationLink = configuration.GetSection("Application:EmailConfirmation").Value;

            string htmlBody = htmlTemplate
          .Replace("{{UserName}}", user.Name)
          .Replace("{{Link}}", string.Format(appDomain + confirmationLink, user.Id, token));

            var mailRequerst = new MailRequest();
            mailRequerst.ToEmail = user.Email;
            mailRequerst.Subject = "Welcome to Juwel Tech ";
            //mailRequerst.Body = "Thanks for subscribing us.";
            mailRequerst.Body = htmlBody;

            await emailService.SendEamilAsync(mailRequerst);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}