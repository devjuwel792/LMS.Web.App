using LMS.Application.Repositories.Base;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Repositories;

public interface ICategoryRepository:IBaseRepository<Category,CategoryVm,long>
{

}
