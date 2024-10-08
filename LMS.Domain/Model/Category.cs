﻿using LMS.Domain.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model;

public class Category : AuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool Default {  get; set; } = false;
    public long RootId { get; set; }
    //public ICollection<Books> Books { get; set; } = new HashSet<Books>();
    public ICollection<Books> Books { get; set; } = new HashSet<Books>();
}