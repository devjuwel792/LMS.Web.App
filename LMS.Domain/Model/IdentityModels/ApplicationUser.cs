using Microsoft.AspNetCore.Identity;

namespace LMS.Domain.Model.IdentityModels;

public class ApplicationUser : IdentityUser
{
    public string? Name { get; set; }
}