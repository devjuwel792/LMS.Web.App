using LMS.Application.Repositories.Base;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LMS.Application.Repositories;

public interface IBooksRepository : IBaseRepository<Books, BooksVm, long>
{
    public IEnumerable<SelectListItem> Dropdown();
}