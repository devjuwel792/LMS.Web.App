using LMS.Application.Repositories;
using LMS.Application.Service;
using LMS.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Controllers;

public class ReportController( IUserService userService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public JsonResult BookIssue(ReportVm report)
    {
        if (userService.IsAuthenticated())
        {
            report.IsApproved = false;
            report.ReturnStatus = false;
            report.UserId = userService.GetUserId();
            report.IssueStatus = true;
            
        }

        return Json(new { message = "Book Issues Sucessfull" });
    }

    [HttpGet]
    public IActionResult BookIssue()
    {
        return View();
    }
}
