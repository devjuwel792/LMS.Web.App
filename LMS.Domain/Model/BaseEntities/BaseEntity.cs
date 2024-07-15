using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model.BaseEntities;

public abstract class BaseEntity<TId>
{
    public TId? Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<long> { }