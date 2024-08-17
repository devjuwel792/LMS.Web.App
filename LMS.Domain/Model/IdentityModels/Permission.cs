using LMS.Domain.Model.BaseEntities;

namespace LMS.Domain.Model.IdentityModels;

public class Permission:AuditableEntity
{

    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}
