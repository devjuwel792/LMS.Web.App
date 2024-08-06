using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Service;

public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    public string? GetUserId()
    {
        return httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public bool? IsAuthenticated()
    {
        return httpContextAccessor.HttpContext.User?.Identity?.IsAuthenticated;
    }
}