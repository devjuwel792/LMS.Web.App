using AutoMapper;
using LMS.Domain.Model;
using LMS.Domain.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel;

[AutoMap(typeof(Books), ReverseMap = true)]
public class BooksVm : AuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Page { get; set; }
    public int Quantity { get; set; }
    public string? Status { get; set; }
    public long Price { get; set; }
    public long PublisherId { get; set; }

    public DateTime? PublisherYear { get; set; }
    public DateTime EditionDate { get; set; }
    public string? CoverImage { get; set; }
    public int ISBN { get; set; }
    public long CategoryId { get; set; }
}