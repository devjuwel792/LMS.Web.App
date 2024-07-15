using AutoMapper;
using LMS.Domain.Model.BaseEntities;
using LMS.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public Task<IModel> DeleteAsync(T id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<IModel>> GetAsync()
    {
        var entities = await DbSet.AsNoTracking().ToListAsync();

        if (entities == null) return null;

        var data = mapper.Map<IEnumerable<IModel>>(entities);

        return data;
    }

    public async Task<IModel> InsartAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        await DbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return mapper.Map<IModel>(entity);
    }

    public Task<IModel> UpdateAsync(T id, TEntity entity)
    {
        throw new NotImplementedException();
    }
}
