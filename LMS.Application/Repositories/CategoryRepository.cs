using AutoMapper;
using LMS.Application.Repositories.Base;
using LMS.Application.ViewModel;
using LMS.Domain.Model;
using LMS.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LMS.Application.Repositories;

public class CategoryRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<Category, CategoryVm, long>(mapper, context), ICategoryRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        var data = DbSet.Where(x => !x.IsDeleted).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList().OrderBy(x => x.Text);
        return data;
    }

    public async Task<IEnumerable<CategoryVm>> DefaultCategory(long id)
    {
        var items = await DbSet.Where(x => x.Default && !x.IsDeleted).AsNoTracking().ToListAsync();
        var CurrentItem = await DbSet.FirstOrDefaultAsync(x => x.Id == id);

        if (CurrentItem != null)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    item.Default = false;
                    DbSet.Update(item);
                    context.SaveChanges();
                }
            }

            CurrentItem.Default = true;
            DbSet.Update(CurrentItem);
            context.SaveChanges();
        }

        return mapper.Map<IEnumerable<CategoryVm>>(items);
    }

    public async Task<long> DefaultCategory()
    {
        var items = await DbSet.FirstOrDefaultAsync(x => x.Default && !x.IsDeleted);

        return items.Id;
    }
}