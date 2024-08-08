using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel.IdentityModelViewModel;

public class ChangePasswordVm
{
    [Required, DataType(DataType.Password), Display(Name = "Current Password")]
    public string? CurrentPassword { get; set; }

    [Required, DataType(DataType.Password), Display(Name = "New Password")]
    public string? NewPassword { get; set; }

    [Required, DataType(DataType.Password), Display(Name = "Confirm Password"), Compare("NewPassword", ErrorMessage = "Confirm new Password does not Match")]
    public string? ConfirmPassword { get; set; }
}