using AutoMapper;
using LMS.Domain.Model;
using LMS.Domain.Model.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel;

[AutoMap(typeof(Books), ReverseMap = true)]
public class BooksVm : AuditableEntity
{
    [DisplayName("Enter Your Book Name  ")]
    public string? Name { get; set; }

    public string? Description { get; set; }
    public int Page { get; set; }
    public int Quantity { get; set; }
    public string? Status { get; set; }
    public long Price { get; set; }

    [DisplayName("Enter Book Publisher ")]

    public long PublisherId { get; set; }

    [DisplayName("Enter Book Publisher Year")]
    [DataType(DataType.Date)]
    public DateTime? PublisherYear { get; set; }

    [DisplayName("Enter Book Edition Date")]
    [DataType(DataType.Date)]
    public DateTime? EditionDate { get; set; }

    [DisplayName("Enter Book Cover Image ")]
    [DataType(DataType.ImageUrl)]
    public string? CoverImage { get; set; }

    public int ISBN { get; set; }

    [DisplayName("Enter Book Category")]
    public long CategoryId { get; set; }
}