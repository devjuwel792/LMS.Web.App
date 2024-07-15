using AutoMapper;
using LMS.Domain.Model;
using LMS.Domain.Model.BaseEntities;

namespace LMS.Application.ViewModel;
[AutoMap(typeof(Category),ReverseMap =true)]
public class CategoryVm : AuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int RootId { get; set; }

}
