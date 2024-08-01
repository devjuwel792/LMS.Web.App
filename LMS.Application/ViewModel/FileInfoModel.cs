using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.ViewModel;

public class FileInfoModel
{
    public string? Name { get; set; }
    public string? Path { get; set; }
    public string? Extentiion { get; set; }
    public long Size { get; set; }
    public DateTime CreationTime { get; set; }
}