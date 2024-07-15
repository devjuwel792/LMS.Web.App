using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model.BaseEntities;

public class AuditableEntity:BaseEntity<long>
{
    public AuditableEntity()=>IsDeleted = false;
    
    public DateTimeOffset CreatedDate { get; set; }
    public long CreateBy {  get; set; }
    public DateTimeOffset UpdatedDate { get; set; }
    public long UpdateBy { get; set; }
    public bool IsDeleted { get; set; }

}
