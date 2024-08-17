using AutoMapper;

using LMS.Application.Repositories;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Controllers
{
    public class HomeController(ICategoryRepository categoryRepository, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await categoryRepository.GetAsync();
            
            return View(data);
        }
        public IActionResult Dashboard()
        {

        return View(); 
        }

        public ActionResult<Category> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new CategoryVm());
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateOrEdit(CategoryVm data, int id)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    data.RootId = data.RootId > 0 ? data.RootId : 0;
                    await categoryRepository.InsartAsync(data);
                    return Json(new { success = true, message = "Category Save successfully!" });
                }
            }

            return View();
        }
    }
}