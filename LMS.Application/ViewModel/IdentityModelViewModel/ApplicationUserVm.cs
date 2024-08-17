using AutoMapper;
using LMS.Domain.Model.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel.IdentityModelViewModel;
[AutoMap(typeof(ApplicationUser), ReverseMap = true)]
public class ApplicationUserVm:IdentityUser
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}