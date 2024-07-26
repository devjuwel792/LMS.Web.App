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

public class PublisherRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Publisher, PublisherVm, long>(mapper, context), IPublisherRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        var data = DbSet.Where(x => x.IsDeleted).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList().OrderBy(x => x.Text);
        return data;
    }
}