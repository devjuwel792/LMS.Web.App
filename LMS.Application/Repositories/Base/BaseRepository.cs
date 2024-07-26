using AutoMapper;
using LMS.Application.ViewModel;
using LMS.Domain.Model.BaseEntities;
using LMS.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LMS.Application.Repositories.Base;

public class BaseRepository<TEntity, IModel, T> : IBaseRepository<TEntity, IModel, T>
    where TEntity : AuditableEntity, new()
    where T : IEquatable<T>
{
    private readonly IMapper mapper;
    private readonly ApplicationDbContext context;
    public DbSet<TEntity> DbSet { get; set; }

    public BaseRepository(IMapper mapper, ApplicationDbContext context)
    {
        this.mapper = mapper;
        this.context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<IModel> DeleteAsync(T id)
    {
        var item = await DbSet.FindAsync(id);
        item.IsDeleted = true;
        DbSet.Update(item);
        await context.SaveChangesAsync();
        return mapper.Map<IModel>(item);
    }

    public async Task<IEnumerable<IModel>> GetAsync()
    {
        var items = await DbSet.Where(x => !x.IsDeleted).AsNoTracking().ToListAsync();
        var entities = mapper.Map<IEnumerable<IModel>>(items);
        if (entities == null) return null;
        return entities;
    }

    public async Task<IModel> InsartAsync(IModel entity)
    {
        var data = mapper.Map<TEntity>(entity);
        data.CreatedDate = DateTime.Now;
        await DbSet.AddAsync(data);
        await context.SaveChangesAsync();
        return mapper.Map<IModel>(entity);
    }

    public async Task<IModel> UpdateAsync(T id, IModel entity)
    {
        var item = await DbSet.FindAsync(id);
        if (item != null)
        {
            item.UpdatedDate = DateTime.Now;
            mapper.Map(entity, item);
            await context.SaveChangesAsync();
        }
        return entity;
    }

    public async Task<IModel> DeleteFromDB(T id)
    {
        var item = await DbSet.FindAsync(id);
        DbSet.Remove(item);
        await context.SaveChangesAsync();
        return mapper.Map<IModel>(item);
    }

    public async Task<IModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await DbSet.Where(x => !x.IsDeleted).FirstOrDefaultAsync(predicate);
        var data = mapper.Map<IModel>(entity);
        return data;
    }
}