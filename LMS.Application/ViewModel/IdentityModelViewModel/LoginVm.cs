﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel.IdentityModelViewModel;

public class LoginVm
{
    [Required, EmailAddress]
    public string? Email { get; set; }
    [Required, DataType(DataType.Password)]
    public string? Password { get; set; }
    public bool RememberMe { get; set; }
   

}