using LMS.Application.Repositories.Base;

using LMS.Application.ViewModel.IdentityModelViewModel;
using LMS.Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace LMS.Application.Repositories;

public interface IAccountRepository 
{
    Task<IEnumerable<ApplicationUserVm>> GetAllUserAsync();
    Task<ApplicationUser> GetUserByEmailAsync(string email);
    Task<IdentityResult> CreateUserAsync(SignUpVm entity);

    Task<SignInResult> PasswordSignInAsync(LoginVm data);

    Task SignOutAsync();

    Task<IdentityResult> ChangePasswordAsync(ChangePasswordVm data);
    Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
    Task GenerateEmailConfirmtionTokenAsync(ApplicationUser user);
}