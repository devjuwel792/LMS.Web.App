using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model.IdentityModels;

public class RolePermission
{
    public string RoleId { get; set; }
    public ApplicationRole Role { get; set; }

    public long PermissionId { get; set; }
    public Permission Permission { get; set; }
}
