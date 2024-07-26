using LMS.Domain.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model;

public class Publisher : AuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Books> Books { get; set; } = new HashSet<Books>();
}