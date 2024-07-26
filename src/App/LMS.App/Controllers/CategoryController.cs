using LMS.Application.Repositories;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.App.Controllers;

public class CategoryController(ICategoryRepository categoryRepository, IBooksRepository booksRepository) : Controller
{
    public IActionResult Index()
    {
        //ViewBag.CategoryList = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "Select One" } }.Concat(categoryRepository.Dropdown()).ToList();

        return View();
    }

    [HttpPost]
    public async Task<JsonResult> CreateOrEdit(CategoryVm data, int id)
    {
        var allItems = await categoryRepository.GetAsync();
        foreach (var item in allItems)
        {
            var a1 =item.Name.ToLower();
            var a2 = data.Name != null ? data.Name.ToLower() : "";
            if (a1 == a2 && item.Id != id)
            {
                return Json(new { message = "All Ready have Data" });
            }
        }

        if (id == 0)
        {
            data.RootId = (data.RootId > 0) ? data.RootId : 0;
            await categoryRepository.InsartAsync(data);

            return Json(new { message = "Category Added Sucessfull" });
        }
        else
        {
            var item = await categoryRepository.FirstOrDefaultAsync(x => x.Id == id);

            data.Default = item.Default;
            await categoryRepository.UpdateAsync(id, data);
            return Json(new { message = "Category Updated Sucessfull" });
        }

        
    }

    //Category delect function
    public async Task<JsonResult> Delete(long id)
    {
        var books = await booksRepository.GetAsync();
        var Currentbooks = books.Where(x => x.CategoryId == id).ToList();
        var defaultCategory = await categoryRepository.DefaultCategory();

        var data = await categoryRepository.GetAsync();
        var s = data.Where(x => x.Default);
        var result = data.FirstOrDefault(data => data.Default == true);
        if (result != null)
        {
            if (result.Id != id)
            {
                foreach (var book in Currentbooks)
                {
                    book.CategoryId = defaultCategory;

                    await booksRepository.UpdateAsync(book.Id, book);
                }
                await categoryRepository.DeleteFromDB(id);
                return Json(new { message = "Category Deleted Sucessfull" });
            }
        }

         return Json(new { message = "Please Change Default Category !" });
    }

    public async Task<ActionResult<Category>> SetAsDefault(long id)
    {
        await categoryRepository.DefaultCategory(id);

        return RedirectToAction("Index", "Home");
    }

    [Route("/get-category-result-by-json")]
    public async Task<JsonResult> GetResultAsync()
    {
        var data = await categoryRepository.GetAsync();
        return Json(data.OrderBy(x => x.Name));
    }

    public async Task<JsonResult> EditCategory(long Id)
    {
        if (Id > 0)
        {
            var data = await categoryRepository.FirstOrDefaultAsync(x => x.Id == Id);

            return Json(data);
        }
        return Json(new { success = false, message = "Category Failed!" });
    }
}