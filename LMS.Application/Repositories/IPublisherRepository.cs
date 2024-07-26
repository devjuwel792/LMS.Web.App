using LMS.Application.Repositories.Base;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Repositories;

public interface IPublisherRepository : IBaseRepository<Publisher, PublisherVm, long>
{
    public IEnumerable<SelectListItem> Dropdown();
}