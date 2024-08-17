using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model.IdentityModels;


public class ApplicationRole : IdentityRole
{
    // Extra fields
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<RolePermission> RolePermissions { get; set; }
}