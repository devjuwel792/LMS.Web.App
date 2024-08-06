using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Model;

public class Report
{
    public Report()
    {
        IssueStatus = false;
        ReturnStatus = false;
    }

    public DateTime? IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public long? BookId { get; set; }
    public Books? Books { get; set; }
    public bool IssueStatus { get; set; }
    public bool ReturnStatus { get; set; }

}
