using LMS.Application.Repositories.Base;

using LMS.Application.ViewModel.IdentityModelViewModel;

using Microsoft.AspNetCore.Identity;


namespace LMS.Application.Repositories;

public interface IAccountRepository
{
    public Task<IdentityResult> CreateUserAsync(SignUpVm entity);
}