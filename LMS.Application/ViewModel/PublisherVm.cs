using AutoMapper;
using LMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel;

[AutoMap(typeof(Publisher), ReverseMap = true)]
public class PublisherVm
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}