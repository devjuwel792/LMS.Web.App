using AutoMapper;
using LMS.Application.ViewModel.IdentityModelViewModel;
using LMS.Domain.Model;
using LMS.Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Repositories;

public class AccountRepository(UserManager<ApplicationUser> userManager, IMapper mapper) : IAccountRepository
{
    private readonly UserManager<ApplicationUser> userManager = userManager;

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
        return result;
    }
}