using AutoMapper;
using LMS.Domain.Model.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel.IdentityModelViewModel;
[AutoMap(typeof(ApplicationUser),ReverseMap =true)]
public class SignUpVm
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}