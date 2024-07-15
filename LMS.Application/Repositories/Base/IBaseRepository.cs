using LMS.Domain.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Repositories.Base;

public interface IBaseRepository<TEntity, IModel, T> where TEntity : AuditableEntity, new()
    where T : IEquatable<T>

{
    #region CRUDOperation
    Task<IEnumerable<IModel>> GetAsync();
    Task<IModel> UpdateAsync(T id, TEntity entity);
    Task<IModel> DeleteAsync(T id);
    Task<IModel> InsartAsync(TEntity entity);

    #endregion
}
