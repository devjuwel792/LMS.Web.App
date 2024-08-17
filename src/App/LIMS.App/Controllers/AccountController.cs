using AutoMapper;
using LMS.Application.Repositories;
using LMS.Application.Service;
using LMS.Application.ViewModel.IdentityModelViewModel;
using LMS.Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;
using System.Configuration;

namespace LMS.App.Controllers;

public class AccountController(IAccountRepository accountRepository, IMapper mapper, IEmailService emailService) : Controller
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
            var result = await accountRepository.CreateUserAsync(entity);

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
    public async Task<IActionResult> Login(LoginVm data, string returnUrl)
    {

        var result = await accountRepository.PasswordSignInAsync(data);
        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        return View(data);
    }

    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await accountRepository.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }


    //[Route("send-mail")]
    //public async Task<IActionResult> SendMail()
    //{
    //    try
    //    {
    //        var mailRequerst = new MailRequest();
    //        mailRequerst.ToEmail = "coddingearth@gmail.com";
    //        mailRequerst.Subject = "Welcome to Juwel Tech";
    //        //mailRequerst.Body = "Thanks for subscribing us.";
    //        mailRequerst.Body = HtmlTemplate();
    //        await emailService.SendEamilAsync(mailRequerst);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw;
    //    }

    //    return View();
    //}

    [Authorize(Roles ="admin")]
    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordVm data)
    {
        if (ModelState.IsValid)
        {
            await accountRepository.ChangePasswordAsync(data);
            ModelState.Clear();
        }

        return View(data);
    }
    [Route("confirm-email")]
    public async Task<IActionResult> EmailConfirm(EmailConfirm data)
    {
        // public async Task<IActionResult> EmailConfirm(string uid, string token)
        //if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
        //{
        //    var result = await accountRepository.ConfirmEmailAsync(uid, token);
        //    if (result.Succeeded)
        //    {
        //        TempData["IsSucess"] = true;
        //        TempData["Url"] = Directory.GetCurrentDirectory();

        //        //TempData["IsSucess"] = true;
        //    }
        //}

        var user = await accountRepository.GetUserByEmailAsync(data.Email);
        if (user != null)
        {
            if (user.EmailConfirmed)
            {
                data.IsConfirmed = true;
                return View(data);
            }
            await accountRepository.GenerateEmailConfirmtionTokenAsync(user);
            data.EmailSent = true;
        }
        else
        {
            ModelState.AddModelError("", "Something went worng");
        }
        return View();
    }

    [Route("change-password")]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [Authorize(Roles = "admin")]
    [Route("all-user")]
    public async Task<IActionResult> GetAllUser()
    {
        var users = await accountRepository.GetAllUserAsync();
      users =  users.ToList();

        return View(users);
    }

    [AllowAnonymous]
    public IActionResult AccessDenied(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

}