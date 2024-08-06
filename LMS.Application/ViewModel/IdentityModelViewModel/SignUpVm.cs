using AutoMapper;
using LMS.Domain.Model.IdentityModels;
using System.ComponentModel.DataAnnotations;


namespace LMS.Application.ViewModel.IdentityModelViewModel;
[AutoMap(typeof(ApplicationUser),ReverseMap =true)]
public class SignUpVm
{
    [Display(Name="Enter Your Name : ")]
    public string? Name { get; set; }
    [Display(Name = "Enter Your Email : ")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }
}