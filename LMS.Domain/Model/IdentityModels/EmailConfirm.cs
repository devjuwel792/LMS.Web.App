using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model.IdentityModels;

public class EmailConfirm
{
    public string Email { get; set; }
    public bool IsConfirmed { get; set; }
    public bool EmailSent { get; set; }

}