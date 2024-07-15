using LMS.Domain.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model;

public class Category:AuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int RootId { get; set; }
}
