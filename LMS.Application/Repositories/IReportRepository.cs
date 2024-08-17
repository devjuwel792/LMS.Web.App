using LMS.Application.Repositories.Base;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.Application.Repositories;

public interface IReportRepository : IBaseRepository<Report, ReportVm, long>
{
    public IEnumerable<SelectListItem> Dropdown();
}