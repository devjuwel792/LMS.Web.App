using AutoMapper;
using LMS.Application.Repositories;
using LMS.Application.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using LMS.Application.Service;

namespace LMS.App.Controllers;

public class BooksController(IBooksRepository booksRepository, ICategoryRepository categoryRepository, IMapper mapper, IUserService userService) : Controller
{
    [Route("/Insart-books")]
    [Authorize]
    public IActionResult InsartBook()
    {
        var userId = userService.GetUserId();
        var auth = userService.IsAuthenticated();
        ViewBag.status = new List<string>() { "Hide", "Show", };
        ViewBag.CategoryList = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "Select One" } }.Concat(categoryRepository.Dropdown()).ToList();
        return View();
    }

    [Route("/get-all-books")]
    public async Task<IActionResult> GetAllBook()
    {
        var data = await booksRepository.GetAsync();
        return View(data);
    }

    public async Task<IActionResult> Index()
    {
        var data = await booksRepository.GetAsync();
        return View(data);
    }

    [HttpPost]
    public async Task<JsonResult> CreateOrEdit(BooksVm book, long id)
    {
        if (id == 0)
        {
            var defaultcategory = await categoryRepository.DefaultCategory();

            book.CategoryId = book.CategoryId == 0 ? defaultcategory : book.CategoryId;
            book.PublisherId = book.PublisherId == 0 ? 1 : book.PublisherId;

            await booksRepository.InsartAsync(book);

            return Json(new { message = "Book Added Sucessfull" });
        }
        else
        {
            await booksRepository.UpdateAsync(id, book);
        }
        return Json(new { message = "Book Added Fail" });
    }

    public async Task<JsonResult> MoveToTrash(long id)
    {
        try
        {
            await booksRepository.DeleteAsync(id);

            return Json(new { message = "Item Moved To Trush" });
        }
        catch (Exception ex)
        {
            return Json(new { message = "Item Delete Fail" });
        }
    }

    [Route("/get-Books-result-by-json")]
    public async Task<JsonResult> GetResultAsync()
    {
        var data = await booksRepository.GetAsync();
        return Json(data.OrderBy(x => x.Name));
    }

    public async Task<JsonResult> EditBookItem(long Id)
    {
        if (Id > 0)
        {
            var data = await booksRepository.FirstOrDefaultAsync(x => x.Id == Id);

            return Json(data);
        }
        return Json(new { success = false, message = "Book Update Failed!" });
    }
}