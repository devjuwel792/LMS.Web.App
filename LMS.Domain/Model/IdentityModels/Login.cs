﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model.IdentityModels;

public class Login
{
    
    public string? Email { get; set; }
   
    public string? Password { get; set; }
    public bool RememberMe { get; set; } = false;

}
