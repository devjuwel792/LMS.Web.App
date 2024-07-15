using AutoMapper;
using LMS.App.Models;
using LMS.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LMS.App.Controllers
{
    public class HomeController(ICategoryRepository categoryRepository,IMapper mapper) : Controller
    {



        public  async Task<IActionResult> Index()
        {
            var data = await categoryRepository.GetAsync();

          
            return View(data);
        }

       
    }
}
