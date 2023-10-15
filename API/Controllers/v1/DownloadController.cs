using Microsoft.AspNetCore.Hosting;
using System.Drawing;

namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DownloadController : BaseController<DoanhNghiep, IDoanhNghiepBusiness>
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly IDoanhNghiepBusiness _DoanhNghiepBusiness;
        private readonly IReportBusiness _ReportBusiness;

        public DownloadController(IWebHostEnvironment WebHostEnvironment
            , IDoanhNghiepBusiness IDoanhNghiepBusiness
            , IReportBusiness ReportBusiness
            ) : base(IDoanhNghiepBusiness)
        {
            _WebHostEnvironment = WebHostEnvironment;
            _DoanhNghiepBusiness = IDoanhNghiepBusiness;
            _ReportBusiness = ReportBusiness;
        }
        [HttpGet]
        [Route("GetMonthToList")]
        public List<YearMonth> GetMonthToList()
        {
            var result = YearMonth.GetMonthToList();
            return result;
        }
        [HttpGet]
        [Route("GetYearToList")]
        public List<YearMonth> GetYearToList()
        {
            var result = YearMonth.GetYearToList();
            return result;
        }
        [HttpPost]
        [Route("Report0004ToExcelAsync")]
        public async Task<JsonResult> Report0004ToExcelAsync()
        {
            long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
            long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
            string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
            string result = GlobalHelper.InitializationString;
            List<Report> list = await _ReportBusiness.Report004Async(huyenID, xaID, searchString);
            string fileName = @"KhachHang_TongThe" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
            var streamExport = new MemoryStream();
            InitializationExcelReport0004(list, streamExport);
            var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
            using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
            {
                streamExport.CopyTo(stream);
            }
            result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
            return Json(result);
        }
        private void InitializationExcelReport0004(List<Report> list, MemoryStream streamExport)
        {
            using (var package = new ExcelPackage(streamExport))
            {
                Color color = Color.FromArgb(int.Parse("#c00000".Replace("#", ""), System.Globalization.NumberStyles.AllowHexSpecifier));
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                int row = 1;
                int column = 1;
                workSheet.Cells[row, column].Value = "Mã số thuế";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Khách hàng";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Huyện";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Xã";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Điện thoại";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Địa chỉ";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Doanh thu";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Cố định";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Chênh lệch";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Di động";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Chênh lệch";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Fiber";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Chênh lệch";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "MyTV";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Chênh lệch";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "An toàn bảo mật thông tin";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Chênh lệch";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Công nghệ thông tin";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Chênh lệch";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Dịch vụ khác";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                column = column + 1;
                workSheet.Cells[row, column].Value = "Chênh lệch";
                workSheet.Cells[row, column].Style.Font.Bold = true;
                workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[row, column].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells[row, column].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[row, column].Style.Fill.BackgroundColor.SetColor(color);
                workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
                workSheet.Cells[row, column].Style.Font.Size = 11;
                workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Top.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Left.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[row, column].Style.Border.Bottom.Color.SetColor(Color.Black);

                row = row + 1;
                foreach (Report item in list)
                {
                    workSheet.Cells[row, 1].Value = item.Code;
                    workSheet.Cells[row, 2].Value = item.Name;
                    workSheet.Cells[row, 3].Value = item.HuyenName;
                    workSheet.Cells[row, 4].Value = item.XaName;
                    workSheet.Cells[row, 5].Value = item.DienThoai;
                    workSheet.Cells[row, 6].Value = item.DiaChi;
                    try
                    {
                        workSheet.Cells[row, 7].Value = item.DoanhThu.Value.ToString("N0");
                        workSheet.Cells[row, 7].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 8].Value = item.DoanhThu01.Value.ToString("N0");
                        workSheet.Cells[row, 8].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 9].Value = item.ChenhLech01.Value.ToString("N0");
                        workSheet.Cells[row, 9].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 10].Value = item.DoanhThu03.Value.ToString("N0");
                        workSheet.Cells[row, 10].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 11].Value = item.ChenhLech02.Value.ToString("N0");
                        workSheet.Cells[row, 11].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 12].Value = item.DoanhThu05.Value.ToString("N0");
                        workSheet.Cells[row, 12].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 13].Value = item.ChenhLech03.Value.ToString("N0");
                        workSheet.Cells[row, 13].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 14].Value = item.DoanhThu07.Value.ToString("N0");
                        workSheet.Cells[row, 14].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 15].Value = item.ChenhLech04.Value.ToString("N0");
                        workSheet.Cells[row, 15].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 16].Value = item.DoanhThu09.Value.ToString("N0");
                        workSheet.Cells[row, 16].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 17].Value = item.ChenhLech05.Value.ToString("N0");
                        workSheet.Cells[row, 17].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 18].Value = item.DoanhThu11.Value.ToString("N0");
                        workSheet.Cells[row, 18].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 19].Value = item.ChenhLech06.Value.ToString("N0");
                        workSheet.Cells[row, 19].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 20].Value = item.DoanhThu13.Value.ToString("N0");
                        workSheet.Cells[row, 20].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }
                    try
                    {
                        workSheet.Cells[row, 21].Value = item.ChenhLech07.Value.ToString("N0");
                        workSheet.Cells[row, 21].Style.Numberformat.Format = "#";
                        workSheet.Cells[row, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    catch (Exception e)
                    {
                    }

                    for (int i = 1; i <= column; i++)
                    {
                        workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
                        workSheet.Cells[row, i].Style.Font.Size = 11;
                        workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, i].Style.Border.Top.Color.SetColor(Color.Black);
                        workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, i].Style.Border.Left.Color.SetColor(Color.Black);
                        workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, i].Style.Border.Right.Color.SetColor(Color.Black);
                        workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[row, i].Style.Border.Bottom.Color.SetColor(Color.Black);
                    }
                    row = row + 1;
                }
                for (int i = 1; i <= column; i++)
                {
                    workSheet.Column(i).AutoFit();
                }
                package.Save();
            }
            streamExport.Position = 0;

        }
    }
}
