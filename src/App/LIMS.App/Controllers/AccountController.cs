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

    [Route("signup")]
    public IActionResult Signup()
    {
        return View();
    }

    [Route("signup")]
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

    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginVm data)
    {
        if (ModelState.IsValid)
        {
            var result = await accountRepository.PasswordSignInAsync(data);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        return View(data);
    }

    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await accountRepository.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}