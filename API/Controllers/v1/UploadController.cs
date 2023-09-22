using Helper;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Drawing;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UploadController : BaseController<DoanhNghiep, IDoanhNghiepBusiness>
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IDoanhNghiepBusiness _IDoanhNghiepBusiness;

        public UploadController(IWebHostEnvironment WebHostEnvironment
            , IDoanhNghiepBusiness IDoanhNghiepBusiness            
            ) : base(IDoanhNghiepBusiness)
        {
            _WebHostEnvironment = WebHostEnvironment;
            _IDoanhNghiepBusiness = IDoanhNghiepBusiness;            
        }
        [HttpPost]
        [Route("PostDoanhNghiepListByExcelFile")]
        public virtual List<DoanhNghiep> PostDoanhNghiepListByExcelFile()
        {
            List<DoanhNghiep> result = new List<DoanhNghiep>();
            if (Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                if (file == null || file.Length == 0)
                {
                }
                if (file != null)
                {
                    string fileExtension = Path.GetExtension(file.FileName);                    
                    string fileName = "DoanhNghiep_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;                    
                    var physicalPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Upload, fileName);
                    using (var stream = new FileStream(physicalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    try
                    {
                        FileInfo fileLocation = new FileInfo(physicalPath);
                        if (fileLocation.Length > 0)
                        {
                            if ((fileExtension == ".xlsx") || (fileExtension == ".xls"))
                            {
                                using (ExcelPackage package = new ExcelPackage(fileLocation))
                                {
                                    if (package.Workbook.Worksheets.Count > 0)
                                    {
                                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                                        if (workSheet != null)
                                        {
                                            int totalRows = workSheet.Dimension.Rows;
                                            for (int i = 2; i <= totalRows; i++)
                                            {
                                               
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string mes = e.Message;
                    }
                }
            }
            return result;
        }
    }
}
