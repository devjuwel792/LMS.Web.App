using AutoMapper;
using LMS.Application.Repositories;
using LMS.Application.ViewModel.IdentityModelViewModel;
using LMS.Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Controllers;

public class AccountController(IAccountRepository accountRepository, IMapper mapper) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Signup()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signup(SignUpVm entity)
    {
        if (ModelState.IsValid)
        {
            await accountRepository.CreateUserAsync(entity);
            ModelState.Clear();
        }
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
}