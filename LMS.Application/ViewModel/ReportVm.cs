using LMS.Domain.Model;
using LMS.Domain.Model.BaseEntities;
using LMS.Domain.Model.IdentityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel;

public class ReportVm :AuditableEntity
{
    public ReportVm()
    {
        IssueStatus = false;
        ReturnStatus = false;
        IsApproved = false;
    }
    public DateTime? IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public long BookId { get; set; }
    public Books Books { get; set; }
    public bool IssueStatus { get; set; }
    public bool ReturnStatus { get; set; }
    public string UserId { get; set; }
    public string RequestStatus { get; set; }
    public bool IsApproved { get; set; }
    public ApplicationUser User { get; set; }
}
