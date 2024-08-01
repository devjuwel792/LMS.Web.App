using LMS.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Controllers;

public class MediaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public JsonResult GetFiles()
    {
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
        string RootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        if (!Directory.Exists(folderPath))
        {
            return Json(new { message = "Directory not found" });
        }

        var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                             .Select(filePath => new FileInfoModel
                             {
                                 Name = Path.GetFileName(filePath),
                                 Path = Path.GetRelativePath(RootPath, filePath).Replace("\\", "/"),
                                 Size = new FileInfo(filePath).Length,
                                 Extentiion = Path.GetExtension(folderPath),
                                 CreationTime = new FileInfo(filePath).CreationTime
                             })
                             .ToList();

        return Json(files);

        //string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        //if (!Directory.Exists(folderPath))
        //{
        //    return NotFound(new { message = "Directory not found" });
        //}

        //var files = Directory.GetFiles(folderPath)
        //                     .Select(Path.GetFileName)
        //                     .ToList();

        //return Ok(files);
    }

    //public IActionResult DeleteFile(string fileName)
    //{
    //    if (string.IsNullOrEmpty(fileName))
    //    {
    //        return BadRequest(new { message = "File name cannot be null or empty" });
    //    }

    //    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

    //    if (System.IO.File.Exists(filePath))
    //    {
    //        System.IO.File.Delete(filePath);
    //        return Ok(new { message = "File deleted successfully" });
    //    }
    //    else
    //    {
    //        return NotFound(new { message = "File not found" });
    //    }
    //}
    public JsonResult DeleteFile([FromQuery] string relativeFilePath)
    {
        if (string.IsNullOrEmpty(relativeFilePath))
        {
            return Json(new { message = "File path cannot be null or empty" });
        }

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativeFilePath);

        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
            return Json(new { message = "File deleted successfully" });
        }
        else
        {
            return Json(new { message = "File not found" });
        }
    }
}