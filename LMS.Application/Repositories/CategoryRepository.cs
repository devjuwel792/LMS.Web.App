using AutoMapper;
using LMS.Application.Repositories.Base;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using LMS.Infrastructure.DatabaseContext;

namespace LMS.Application.Repositories;

public class CategoryRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Category, CategoryVm, long>(mapper, context), ICategoryRepository
{
}
