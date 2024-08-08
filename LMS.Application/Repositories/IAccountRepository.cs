using LMS.Application.Repositories.Base;

using LMS.Application.ViewModel.IdentityModelViewModel;
using Microsoft.AspNetCore.Identity;

namespace LMS.Application.Repositories;

public interface IAccountRepository
{
    Task<IdentityResult> CreateUserAsync(SignUpVm entity);

    Task<SignInResult> PasswordSignInAsync(LoginVm data);

    Task SignOutAsync();

    Task<IdentityResult> ChangePasswordAsync(ChangePasswordVm data);
}