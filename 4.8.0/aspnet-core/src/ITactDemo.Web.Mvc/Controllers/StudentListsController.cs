using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITactDemo.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;
using Abp.UI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using Microsoft.AspNetCore.Hosting;

namespace ITactDemo.Web.Mvc.Controllers
{
    public class StudentListsController : ITactDemoControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        public StudentListsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import()
        {
            IFormFile file = Request.Form.Files[0];
            string FolderPath = Path.Combine(AppConsts.rootPath, AppConsts.UploadExcelFile);
            StringBuilder stringBuilder = new StringBuilder();
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            if (file.Length > 0)
            {
                string fileExtension = Path.GetExtension(file.FileName).ToLower();    
                ISheet sheet;
                string SavePath = Path.Combine(FolderPath, file.FileName);
                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                   file.CopyTo(stream);
                   stream.Position = 0;
                   if(fileExtension == ".xls")
                   {
                      HSSFWorkbook book = new HSSFWorkbook(stream);
                      sheet = book.GetSheetAt(0);
                   }
                   else
                   {
                      XSSFWorkbook workbook = new XSSFWorkbook(stream);
                      sheet = workbook.GetSheetAt(0);
                   }
                   IRow headerRow = sheet.GetRow(0);
                   int cellCount = headerRow.LastCellNum;
                   stringBuilder.Append("<table class='table'><tr>");
                   for(int i=0;i<cellCount;i++)
                   {
                      NPOI.SS.UserModel.ICell cell = headerRow.GetCell(i);
                      if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                      stringBuilder.Append("<th>" + cell.ToString() + "</th>");
                   }
                   stringBuilder.Append("</tr>");
                   stringBuilder.AppendLine("<tr>");
                   for(int i=(sheet.FirstRowNum+1);i<=sheet.LastRowNum;i++)
                   {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(c => c.CellType == CellType.Blank)) continue;
                        for(int j=row.FirstCellNum;j<cellCount;j++)
                        {
                            if(row.GetCell(j)!=null)
                            {
                                stringBuilder.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                            }   
                        }
                        stringBuilder.AppendLine("</tr>");
                   }
                   stringBuilder.Append("</table>");
                }
            }
            return this.Content(stringBuilder.ToString());
        }
    }
}