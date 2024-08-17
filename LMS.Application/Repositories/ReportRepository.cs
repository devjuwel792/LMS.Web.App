using AutoMapper;
using LMS.Application.Repositories.Base;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using LMS.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Repositories;

public class ReportRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Report, ReportVm, long>(mapper, context),IReportRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        throw new NotImplementedException();
    }

   
}
