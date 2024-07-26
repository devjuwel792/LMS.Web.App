using LMS.Domain.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Repositories.Base;

public interface IBaseRepository<TEntity, IModel, T> where TEntity : AuditableEntity, new()
    where T : IEquatable<T>

{
    #region CRUDOperation

    Task<IEnumerable<IModel>> GetAsync();

    Task<IModel> UpdateAsync(T id, IModel entity);

    Task<IModel> DeleteAsync(T id);
    Task<IModel> DeleteFromDB(T id);

    Task<IModel> InsartAsync(IModel entity);

    #endregion CRUDOperation

    #region FirstOrDefault

    public Task<IModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

    #endregion FirstOrDefault
}