namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class DownloadController : BaseController<DoanhNghiep, IDoanhNghiepBusiness>
	{
		private readonly IWebHostEnvironment _WebHostEnvironment;
		private readonly IDoanhNghiepBusiness _DoanhNghiepBusiness;
		private readonly IHuyenBusiness _HuyenBusiness;
		private readonly IReportBusiness _ReportBusiness;

		public DownloadController(IWebHostEnvironment WebHostEnvironment
			, IDoanhNghiepBusiness DoanhNghiepBusiness
			, IHuyenBusiness HuyenBusiness
			, IReportBusiness ReportBusiness
			) : base(DoanhNghiepBusiness)
		{
			_WebHostEnvironment = WebHostEnvironment;
			_DoanhNghiepBusiness = DoanhNghiepBusiness;
			_HuyenBusiness = HuyenBusiness;
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
		[Route("ReportCA203_204_206_207ToHTMLAsync")]
		public async Task<JsonResult> ReportCA203_204_206_207ToHTMLAsync()
		{
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> listReportCA203 = await _ReportBusiness.ReportCA203Async(year, month);
			List<Report> listReportCA204 = await _ReportBusiness.ReportCA204Async(year, month);
			List<Report> listReportCA206 = await _ReportBusiness.ReportCA206Async(year, month);
			List<Report> listReportCA207 = await _ReportBusiness.ReportCA207Async(year, month);
			string contentHTML = GlobalHelper.InitializationString;
			var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "DoanhNghiepDichVuCABaoCaoTongHop.html");
			using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
			{
				using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
				{
					contentHTML = r.ReadToEnd();
				}
			}
			if (listReportCA203.Count > 0)
			{
				StringBuilder contentReportCA203 = new StringBuilder();
				int stt = 0;
				foreach (Report report in listReportCA203)
				{
					stt = stt + 1;
					contentReportCA203.AppendLine(@"<tr>");
					contentReportCA203.AppendLine(@"<td style='text-align: center;'>" + stt + "</td>");
					contentReportCA203.AppendLine(@"<td><b>" + report.NhanVienTaoYeuCauName + "</b></td>");
					contentReportCA203.AppendLine(@"<td style='text-align: right;'>" + report.SanLuong.Value.ToString("N0") + "</td>");
					contentReportCA203.AppendLine(@"<td style='text-align: right;'>" + report.PhatTrienChiTieu.Value.ToString("N0") + "</td>");
					contentReportCA203.AppendLine(@"<td style='text-align: right;'>" + report.DoanhThu.Value.ToString("N0") + "</td>");
					contentReportCA203.AppendLine(@"<td style='text-align: right;'>" + report.TyLePhatTrien.Value.ToString("N0") + " %</td>");
					contentReportCA203.AppendLine(@"</tr>");
				}
				contentHTML = contentHTML.Replace("[NhanVienXepHang]", contentReportCA203.ToString());
			}
			if (listReportCA204.Count > 0)
			{
				StringBuilder contentReportCA204 = new StringBuilder();
				int stt = 0;
				foreach (Report report in listReportCA204)
				{
					stt = stt + 1;
					contentReportCA204.AppendLine(@"<tr>");
					contentReportCA204.AppendLine(@"<td style='text-align: center;'>" + stt + "</td>");
					contentReportCA204.AppendLine(@"<td><b>" + report.PhongBanTaoYeuCauName + "</b></td>");
					contentReportCA204.AppendLine(@"<td style='text-align: right;'>" + report.SanLuong.Value.ToString("N0") + "</td>");
					contentReportCA204.AppendLine(@"<td style='text-align: right;'>" + report.PhatTrienChiTieu.Value.ToString("N0") + "</td>");
					contentReportCA204.AppendLine(@"<td style='text-align: right;'>" + report.DoanhThu.Value.ToString("N0") + "</td>");
					contentReportCA204.AppendLine(@"<td style='text-align: right;'>" + report.TyLePhatTrien.Value.ToString("N0") + " %</td>");
					contentReportCA204.AppendLine(@"</tr>");
				}
				contentHTML = contentHTML.Replace("[PhongBanHangXepHang]", contentReportCA204.ToString());
			}
			if (listReportCA206.Count > 0)
			{
				StringBuilder contentReportCA206 = new StringBuilder();
				int stt = 0;
				foreach (Report report in listReportCA206)
				{
					stt = stt + 1;
					contentReportCA206.AppendLine(@"<tr>");
					contentReportCA206.AppendLine(@"<td style='text-align: center;'>" + stt + "</td>");
					contentReportCA206.AppendLine(@"<td><b>" + report.NhanVienTaoYeuCauName + "</b></td>");
					contentReportCA206.AppendLine(@"<td style='text-align: right;'>" + report.HoSo.Value.ToString("N0") + "</td>");
					contentReportCA206.AppendLine(@"<td style='text-align: right;'>" + report.HoSoHoanThanh.Value.ToString("N0") + "</td>");
					contentReportCA206.AppendLine(@"<td style='text-align: right;'>" + report.HoSoChuaHoanThanh.Value.ToString("N0") + "</td>");
					decimal tyLe = 0;
					if (report.HoSo != 0)
					{
						tyLe = report.HoSoHoanThanh.Value * 100 / report.HoSo.Value;
					}
					contentReportCA206.AppendLine(@"<td style='text-align: right;'>" + tyLe.ToString("N0") + " %</td>");
					contentReportCA206.AppendLine(@"</tr>");
				}
				contentHTML = contentHTML.Replace("[NhanVienBaoCao]", contentReportCA206.ToString());
			}
			if (listReportCA207.Count > 0)
			{
				StringBuilder contentReportCA207 = new StringBuilder();
				int stt = 0;
				foreach (Report report in listReportCA207)
				{
					stt = stt + 1;
					contentReportCA207.AppendLine(@"<tr>");
					contentReportCA207.AppendLine(@"<td style='text-align: center;'>" + stt + "</td>");
					contentReportCA207.AppendLine(@"<td><b>" + report.PhongBanTaoYeuCauName + "</b></td>");
					contentReportCA207.AppendLine(@"<td style='text-align: right;'>" + report.HoSo.Value.ToString("N0") + "</td>");
					contentReportCA207.AppendLine(@"<td style='text-align: right;'>" + report.HoSoHoanThanh.Value.ToString("N0") + "</td>");
					contentReportCA207.AppendLine(@"<td style='text-align: right;'>" + report.HoSoChuaHoanThanh.Value.ToString("N0") + "</td>");					
					decimal tyLe = 0;
					if (report.HoSo != 0)
					{
						tyLe = report.HoSoHoanThanh.Value * 100 / report.HoSo.Value;
					}
					contentReportCA207.AppendLine(@"<td style='text-align: right;'>" + tyLe.ToString("N0") + " %</td>");
					contentReportCA207.AppendLine(@"</tr>");
				}
				contentHTML = contentHTML.Replace("[PhongBanHangBaoCao]", contentReportCA207.ToString());
			}
			contentHTML = contentHTML.Replace("[Year]", GlobalHelper.InitializationDateTime.Year.ToString());
			contentHTML = contentHTML.Replace("[Month]", GlobalHelper.InitializationDateTime.Month.ToString());
			contentHTML = contentHTML.Replace("[Day]", GlobalHelper.InitializationDateTime.Day.ToString());
			string fileName = "ReportCA203_204_206_207_" + GlobalHelper.InitializationDateTimeCode0001 + ".html";
			result = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (FileStream fs = new FileStream(result, FileMode.Create))
			{
				using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
				{
					w.WriteLine(contentHTML);
				}
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}

		[HttpPost]
		[Route("ReportCA503_504_506_507ToHTMLAsync")]
		public async Task<JsonResult> ReportCA503_504_506_507ToHTMLAsync()
		{
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
			string result = GlobalHelper.InitializationString;
			List<Report> listReportCA203 = await _ReportBusiness.ReportCA503Async(year, month, isSmartCA);
			List<Report> listReportCA204 = await _ReportBusiness.ReportCA504Async(year, month, isSmartCA);
			List<Report> listReportCA206 = await _ReportBusiness.ReportCA506Async(year, month, isSmartCA);
			List<Report> listReportCA207 = await _ReportBusiness.ReportCA507Async(year, month, isSmartCA);
			string contentHTML = GlobalHelper.InitializationString;
			var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "DoanhNghiepDichVuCABaoCaoTongHop.html");
			using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
			{
				using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
				{
					contentHTML = r.ReadToEnd();
				}
			}
			if (listReportCA203.Count > 0)
			{
				StringBuilder contentReportCA203 = new StringBuilder();
				int stt = 0;
				foreach (Report report in listReportCA203)
				{
					stt = stt + 1;
					contentReportCA203.AppendLine(@"<tr>");
					contentReportCA203.AppendLine(@"<td style='text-align: center;'>" + stt + "</td>");
					contentReportCA203.AppendLine(@"<td><b>" + report.NhanVienTaoYeuCauName + "</b></td>");
					contentReportCA203.AppendLine(@"<td style='text-align: right;'>" + report.SanLuong.Value.ToString("N0") + "</td>");
					contentReportCA203.AppendLine(@"<td style='text-align: right;'>" + report.PhatTrienChiTieu.Value.ToString("N0") + "</td>");
					contentReportCA203.AppendLine(@"<td style='text-align: right;'>" + report.DoanhThu.Value.ToString("N0") + "</td>");
					contentReportCA203.AppendLine(@"<td style='text-align: right;'>" + report.TyLePhatTrien.Value.ToString("N0") + " %</td>");
					contentReportCA203.AppendLine(@"</tr>");
				}
				contentHTML = contentHTML.Replace("[NhanVienXepHang]", contentReportCA203.ToString());
			}
			if (listReportCA204.Count > 0)
			{
				StringBuilder contentReportCA204 = new StringBuilder();
				int stt = 0;
				foreach (Report report in listReportCA204)
				{
					stt = stt + 1;
					contentReportCA204.AppendLine(@"<tr>");
					contentReportCA204.AppendLine(@"<td style='text-align: center;'>" + stt + "</td>");
					contentReportCA204.AppendLine(@"<td><b>" + report.PhongBanTaoYeuCauName + "</b></td>");
					contentReportCA204.AppendLine(@"<td style='text-align: right;'>" + report.SanLuong.Value.ToString("N0") + "</td>");
					contentReportCA204.AppendLine(@"<td style='text-align: right;'>" + report.PhatTrienChiTieu.Value.ToString("N0") + "</td>");
					contentReportCA204.AppendLine(@"<td style='text-align: right;'>" + report.DoanhThu.Value.ToString("N0") + "</td>");
					contentReportCA204.AppendLine(@"<td style='text-align: right;'>" + report.TyLePhatTrien.Value.ToString("N0") + " %</td>");
					contentReportCA204.AppendLine(@"</tr>");
				}
				contentHTML = contentHTML.Replace("[PhongBanHangXepHang]", contentReportCA204.ToString());
			}
			if (listReportCA206.Count > 0)
			{
				StringBuilder contentReportCA206 = new StringBuilder();
				int stt = 0;
				foreach (Report report in listReportCA206)
				{
					stt = stt + 1;
					contentReportCA206.AppendLine(@"<tr>");
					contentReportCA206.AppendLine(@"<td style='text-align: center;'>" + stt + "</td>");
					contentReportCA206.AppendLine(@"<td><b>" + report.NhanVienTaoYeuCauName + "</b></td>");
					contentReportCA206.AppendLine(@"<td style='text-align: right;'>" + report.HoSo.Value.ToString("N0") + "</td>");
					contentReportCA206.AppendLine(@"<td style='text-align: right;'>" + report.HoSoHoanThanh.Value.ToString("N0") + "</td>");
					contentReportCA206.AppendLine(@"<td style='text-align: right;'>" + report.HoSoChuaHoanThanh.Value.ToString("N0") + "</td>");
					decimal tyLe = 0;
					if (report.HoSo != 0)
					{
						tyLe = report.HoSoHoanThanh.Value * 100 / report.HoSo.Value;
					}
					contentReportCA206.AppendLine(@"<td style='text-align: right;'>" + tyLe.ToString("N0") + " %</td>");
					contentReportCA206.AppendLine(@"</tr>");
				}
				contentHTML = contentHTML.Replace("[NhanVienBaoCao]", contentReportCA206.ToString());
			}
			if (listReportCA207.Count > 0)
			{
				StringBuilder contentReportCA207 = new StringBuilder();
				int stt = 0;
				foreach (Report report in listReportCA207)
				{
					stt = stt + 1;
					contentReportCA207.AppendLine(@"<tr>");
					contentReportCA207.AppendLine(@"<td style='text-align: center;'>" + stt + "</td>");
					contentReportCA207.AppendLine(@"<td><b>" + report.PhongBanTaoYeuCauName + "</b></td>");
					contentReportCA207.AppendLine(@"<td style='text-align: right;'>" + report.HoSo.Value.ToString("N0") + "</td>");
					contentReportCA207.AppendLine(@"<td style='text-align: right;'>" + report.HoSoHoanThanh.Value.ToString("N0") + "</td>");
					contentReportCA207.AppendLine(@"<td style='text-align: right;'>" + report.HoSoChuaHoanThanh.Value.ToString("N0") + "</td>");
					decimal tyLe = 0;
					if (report.HoSo != 0)
					{
						tyLe = report.HoSoHoanThanh.Value * 100 / report.HoSo.Value;
					}
					contentReportCA207.AppendLine(@"<td style='text-align: right;'>" + tyLe.ToString("N0") + " %</td>");
					contentReportCA207.AppendLine(@"</tr>");
				}
				contentHTML = contentHTML.Replace("[PhongBanHangBaoCao]", contentReportCA207.ToString());
			}
			contentHTML = contentHTML.Replace("[Year]", GlobalHelper.InitializationDateTime.Year.ToString());
			contentHTML = contentHTML.Replace("[Month]", GlobalHelper.InitializationDateTime.Month.ToString());
			contentHTML = contentHTML.Replace("[Day]", GlobalHelper.InitializationDateTime.Day.ToString());
			string fileName = "ReportCA203_204_206_207_" + GlobalHelper.InitializationDateTimeCode0001 + ".html";
			result = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (FileStream fs = new FileStream(result, FileMode.Create))
			{
				using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
				{
					w.WriteLine(contentHTML);
				}
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportVNPT001ToExcelAsync")]
		public async Task<JsonResult> ReportVNPT001ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
			string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportVNPT001Async(huyenID, xaID, searchString, year, month);
			string fileName = @"Report_TongHop" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportVNPT001(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportVNPT003ToExcelAsync")]
		public async Task<JsonResult> ReportVNPT003ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			long xaID = JsonConvert.DeserializeObject<long>(Request.Form["xaID"]);
			string searchString = JsonConvert.DeserializeObject<string>(Request.Form["searchString"]);
			long dichVuID = JsonConvert.DeserializeObject<long>(Request.Form["dichVuID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportVNPT003Async(huyenID, xaID, searchString, dichVuID, year, month);
			string fileName = @"Report_DichVu" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportVNPT003(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportVNPT004ToExcelAsync")]
		public async Task<JsonResult> ReportVNPT004ToExcelAsync()
		{
			long phongBanID = JsonConvert.DeserializeObject<long>(Request.Form["phongBanID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportVNPT004Async(phongBanID, year);
			string fileName = @"Report_PhongBan" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportVNPT004(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportVNPT005ToExcelAsync")]
		public async Task<JsonResult> ReportVNPT005ToExcelAsync()
		{
			long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportVNPT005Async(nhanVienID, year);
			string fileName = @"Report_NhanVien" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportVNPT005(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}

		[HttpPost]
		[Route("DoanhNghiepMaSoThueKhongTonTaiToExcelAsync")]
		public async Task<JsonResult> DoanhNghiepMaSoThueKhongTonTaiToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			List<DoanhNghiep> list = await _DoanhNghiepBusiness.GetMaSoThueKhongTonTaiToListAsync();
			string fileName = @"DoanhNghiepMaSoThueKhongTonTai" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelDoanhNghiep(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}

		[HttpPost]
		[Route("ReportCA001ToExcelAsync")]
		public async Task<JsonResult> ReportCA001ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportCA001Async(huyenID, year, month);
			string fileName = @"Report_CA" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportCA(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA002ToExcelAsync")]
		public async Task<JsonResult> ReportCA002ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportCA002Async(huyenID, year, month);
			string fileName = @"Report_CA" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportCA(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA003ToExcelAsync")]
		public async Task<JsonResult> ReportCA003ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportCA003Async(huyenID, year, month);
			string fileName = @"Report_CA" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportCA(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA004ToExcelAsync")]
		public async Task<JsonResult> ReportCA004ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportCA004Async(huyenID, year, month);
			string fileName = @"Report_CA" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportCA(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA005ToExcelAsync")]
		public async Task<JsonResult> ReportCA005ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportCA005Async(huyenID, year, month);
			string fileName = @"Report_CA" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportCA(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA006ToExcelAsync")]
		public async Task<JsonResult> ReportCA006ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportCA006Async(huyenID, year, month);
			string fileName = @"Report_CA" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportCA(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA007ToExcelAsync")]
		public async Task<JsonResult> ReportCA007ToExcelAsync()
		{
			long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
			int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
			int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
			string result = GlobalHelper.InitializationString;
			List<Report> list = await _ReportBusiness.ReportCA007Async(huyenID, year, month);
			string fileName = @"Report_CA" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
			var streamExport = new MemoryStream();
			InitializationExcelReportCA(list, streamExport);
			var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
			using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
			{
				streamExport.CopyTo(stream);
			}
			result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA101ToExcelAsync")]
		public async Task<JsonResult> ReportCA101ToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);

				List<Report> list = await _ReportBusiness.ReportCA101Async(huyenID, year, month, nhanVienID);
				string fileName = @"Report_CA_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
				var streamExport = new MemoryStream();
				InitializationExcelReportCA(list, streamExport);
				var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
				using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
				{
					streamExport.CopyTo(stream);
				}
				result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA401ToExcelAsync")]
		public async Task<JsonResult> ReportCA401ToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);

				List<Report> list = await _ReportBusiness.ReportCA401Async(huyenID, year, month, nhanVienID, isSmartCA);
				string fileName = @"Report_CA_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
				var streamExport = new MemoryStream();
				InitializationExcelReportCA(list, streamExport);
				var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
				using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
				{
					streamExport.CopyTo(stream);
				}
				result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA102ToExcelAsync")]
		public async Task<JsonResult> ReportCA102ToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);

				List<Report> list = await _ReportBusiness.ReportCA102Async(huyenID, year, month, nhanVienID);
				string fileName = @"Report_CA_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
				var streamExport = new MemoryStream();
				InitializationExcelReportCA(list, streamExport);
				var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
				using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
				{
					streamExport.CopyTo(stream);
				}
				result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA402ToExcelAsync")]
		public async Task<JsonResult> ReportCA402ToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);

				List<Report> list = await _ReportBusiness.ReportCA402Async(huyenID, year, month, nhanVienID, isSmartCA);
				string fileName = @"Report_CA_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
				var streamExport = new MemoryStream();
				InitializationExcelReportCA(list, streamExport);
				var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
				using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
				{
					streamExport.CopyTo(stream);
				}
				result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA105ToExcelAsync")]
		public async Task<JsonResult> ReportCA105ToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				int hetHan = JsonConvert.DeserializeObject<int>(Request.Form["hetHan"]);

				List<Report> list = await _ReportBusiness.ReportCA105Async(huyenID, year, month, nhanVienID, hetHan);
				string fileName = @"Report_CA_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
				var streamExport = new MemoryStream();
				InitializationExcelReportCA(list, streamExport);
				var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
				using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
				{
					streamExport.CopyTo(stream);
				}
				result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA405ToExcelAsync")]
		public async Task<JsonResult> ReportCA405ToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				int hetHan = JsonConvert.DeserializeObject<int>(Request.Form["hetHan"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);

				List<Report> list = await _ReportBusiness.ReportCA405Async(huyenID, year, month, nhanVienID, hetHan, isSmartCA);
				string fileName = @"Report_CA_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
				var streamExport = new MemoryStream();
				InitializationExcelReportCA(list, streamExport);
				var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
				using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
				{
					streamExport.CopyTo(stream);
				}
				result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA108ToExcelAsync")]
		public async Task<JsonResult> ReportCA108ToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isKetLuan = JsonConvert.DeserializeObject<bool>(Request.Form["isKetLuan"]);

				List<Report> list = await _ReportBusiness.ReportCA108Async(huyenID, year, month, nhanVienID, isKetLuan);
				string fileName = @"Report_CA_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
				var streamExport = new MemoryStream();
				InitializationExcelReportCA(list, streamExport);
				var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
				using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
				{
					streamExport.CopyTo(stream);
				}
				result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Json(result);
		}
		[HttpPost]
		[Route("ReportCA408ToExcelAsync")]
		public async Task<JsonResult> ReportCA408ToExcelAsync()
		{
			string result = GlobalHelper.InitializationString;
			try
			{
				long huyenID = JsonConvert.DeserializeObject<long>(Request.Form["huyenID"]);
				int year = JsonConvert.DeserializeObject<int>(Request.Form["year"]);
				int month = JsonConvert.DeserializeObject<int>(Request.Form["month"]);
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				bool isKetLuan = JsonConvert.DeserializeObject<bool>(Request.Form["isKetLuan"]);
				bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["isSmartCA"]);
				List<Report> list = await _ReportBusiness.ReportCA408Async(huyenID, year, month, nhanVienID, isKetLuan, isSmartCA);
				string fileNameSub = "VNPTCA";
				if (isSmartCA == true)
				{
					fileNameSub = "SMARTCA";
				}
				string fileName = @"Report_" + fileNameSub + "_" + GlobalHelper.InitializationDateTimeCode + ".xlsx";
				var streamExport = new MemoryStream();
				InitializationExcelReportCA(list, streamExport);
				var physicalPathCreate = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, fileName);
				using (var stream = new FileStream(physicalPathCreate, FileMode.Create))
				{
					streamExport.CopyTo(stream);
				}
				result = GlobalHelper.APISite + GlobalHelper.Download + "/" + fileName;
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return Json(result);
		}
		private void InitializationExcelReportVNPT001(List<Report> list, MemoryStream streamExport)
		{
			using (var package = new ExcelPackage(streamExport))
			{
				var workSheet = package.Workbook.Worksheets.Add("Sheet1");
				int row = 1;
				int column = 1;
				workSheet.Cells[row, column].Value = "Mã số thuế";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Khách hàng";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Huyện";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Xã";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Điện thoại";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Địa chỉ";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Doanh thu";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chênh lệch";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Cố định";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chênh lệch";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Di động";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chênh lệch";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Fiber";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chênh lệch";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "MyTV";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chênh lệch";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "An toàn bảo mật thông tin";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chênh lệch";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Công nghệ thông tin";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chênh lệch";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Dịch vụ khác";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chênh lệch";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


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
						workSheet.Cells[row, 8].Value = item.ChenhLech.Value.ToString("N0");
						workSheet.Cells[row, 8].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 9].Value = item.DoanhThu01.Value.ToString("N0");
						workSheet.Cells[row, 9].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 10].Value = item.ChenhLech01.Value.ToString("N0");
						workSheet.Cells[row, 10].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 11].Value = item.DoanhThu03.Value.ToString("N0");
						workSheet.Cells[row, 11].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 12].Value = item.ChenhLech02.Value.ToString("N0");
						workSheet.Cells[row, 12].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 13].Value = item.DoanhThu05.Value.ToString("N0");
						workSheet.Cells[row, 13].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 14].Value = item.ChenhLech03.Value.ToString("N0");
						workSheet.Cells[row, 14].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 15].Value = item.DoanhThu07.Value.ToString("N0");
						workSheet.Cells[row, 15].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 16].Value = item.ChenhLech04.Value.ToString("N0");
						workSheet.Cells[row, 16].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 17].Value = item.DoanhThu09.Value.ToString("N0");
						workSheet.Cells[row, 17].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 18].Value = item.ChenhLech05.Value.ToString("N0");
						workSheet.Cells[row, 18].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 19].Value = item.DoanhThu11.Value.ToString("N0");
						workSheet.Cells[row, 19].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 20].Value = item.ChenhLech06.Value.ToString("N0");
						workSheet.Cells[row, 20].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 21].Value = item.DoanhThu13.Value.ToString("N0");
						workSheet.Cells[row, 21].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 21].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 22].Value = item.ChenhLech07.Value.ToString("N0");
						workSheet.Cells[row, 22].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 22].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}

					for (int i = 1; i <= column; i++)
					{
						workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
						workSheet.Cells[row, i].Style.Font.Size = 11;
						workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

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
		private void InitializationExcelReportVNPT003(List<Report> list, MemoryStream streamExport)
		{
			using (var package = new ExcelPackage(streamExport))
			{
				var workSheet = package.Workbook.Worksheets.Add("Sheet1");
				int row = 1;
				int column = 1;
				workSheet.Cells[row, column].Value = "Mã số thuế";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Khách hàng";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Huyện";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Xã";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Điện thoại";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Địa chỉ";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Dịch vụ";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Năm";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Doanh thu";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 01";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 02";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 03";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 04";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 05";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 06";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 07";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 08";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 09";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 10";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 11";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 12";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				row = row + 1;
				foreach (Report item in list)
				{
					workSheet.Cells[row, 1].Value = item.Code;
					workSheet.Cells[row, 2].Value = item.Name;
					workSheet.Cells[row, 3].Value = item.HuyenName;
					workSheet.Cells[row, 4].Value = item.XaName;
					workSheet.Cells[row, 5].Value = item.DienThoai;
					workSheet.Cells[row, 6].Value = item.DiaChi;
					workSheet.Cells[row, 7].Value = item.DichVu;
					workSheet.Cells[row, 8].Value = item.Year;
					try
					{
						workSheet.Cells[row, 9].Value = item.DoanhThu.Value.ToString("N0");
						workSheet.Cells[row, 9].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 10].Value = item.DoanhThu01.Value.ToString("N0");
						workSheet.Cells[row, 10].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 11].Value = item.DoanhThu02.Value.ToString("N0");
						workSheet.Cells[row, 11].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 12].Value = item.DoanhThu03.Value.ToString("N0");
						workSheet.Cells[row, 12].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 13].Value = item.DoanhThu04.Value.ToString("N0");
						workSheet.Cells[row, 13].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 14].Value = item.DoanhThu05.Value.ToString("N0");
						workSheet.Cells[row, 14].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 15].Value = item.DoanhThu06.Value.ToString("N0");
						workSheet.Cells[row, 15].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 16].Value = item.DoanhThu07.Value.ToString("N0");
						workSheet.Cells[row, 16].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 17].Value = item.DoanhThu08.Value.ToString("N0");
						workSheet.Cells[row, 17].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 18].Value = item.DoanhThu09.Value.ToString("N0");
						workSheet.Cells[row, 18].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 19].Value = item.DoanhThu10.Value.ToString("N0");
						workSheet.Cells[row, 19].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 20].Value = item.DoanhThu11.Value.ToString("N0");
						workSheet.Cells[row, 20].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 21].Value = item.DoanhThu12.Value.ToString("N0");
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

						workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

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

		private void InitializationExcelReportVNPT004(List<Report> list, MemoryStream streamExport)
		{
			using (var package = new ExcelPackage(streamExport))
			{
				var workSheet = package.Workbook.Worksheets.Add("Sheet1");
				int row = 1;
				int column = 1;
				workSheet.Cells[row, column].Value = "Mã số thuế";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Khách hàng";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Huyện";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Xã";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Điện thoại";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Địa chỉ";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Phòng ban";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Năm";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Doanh thu";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 01";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 02";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 03";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 04";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 05";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 06";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 07";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 08";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 09";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 10";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 11";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 12";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				row = row + 1;
				foreach (Report item in list)
				{
					workSheet.Cells[row, 1].Value = item.Code;
					workSheet.Cells[row, 2].Value = item.Name;
					workSheet.Cells[row, 3].Value = item.HuyenName;
					workSheet.Cells[row, 4].Value = item.XaName;
					workSheet.Cells[row, 5].Value = item.DienThoai;
					workSheet.Cells[row, 6].Value = item.DiaChi;
					workSheet.Cells[row, 7].Value = item.PhongBan;
					workSheet.Cells[row, 8].Value = item.Year;
					try
					{
						workSheet.Cells[row, 9].Value = item.DoanhThu.Value.ToString("N0");
						workSheet.Cells[row, 9].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 10].Value = item.DoanhThu01.Value.ToString("N0");
						workSheet.Cells[row, 10].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 11].Value = item.DoanhThu02.Value.ToString("N0");
						workSheet.Cells[row, 11].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 12].Value = item.DoanhThu03.Value.ToString("N0");
						workSheet.Cells[row, 12].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 13].Value = item.DoanhThu04.Value.ToString("N0");
						workSheet.Cells[row, 13].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 14].Value = item.DoanhThu05.Value.ToString("N0");
						workSheet.Cells[row, 14].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 15].Value = item.DoanhThu06.Value.ToString("N0");
						workSheet.Cells[row, 15].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 16].Value = item.DoanhThu07.Value.ToString("N0");
						workSheet.Cells[row, 16].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 17].Value = item.DoanhThu08.Value.ToString("N0");
						workSheet.Cells[row, 17].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 18].Value = item.DoanhThu09.Value.ToString("N0");
						workSheet.Cells[row, 18].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 19].Value = item.DoanhThu10.Value.ToString("N0");
						workSheet.Cells[row, 19].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 20].Value = item.DoanhThu11.Value.ToString("N0");
						workSheet.Cells[row, 20].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 21].Value = item.DoanhThu12.Value.ToString("N0");
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

						workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

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
		private void InitializationExcelReportVNPT005(List<Report> list, MemoryStream streamExport)
		{
			using (var package = new ExcelPackage(streamExport))
			{
				var workSheet = package.Workbook.Worksheets.Add("Sheet1");
				int row = 1;
				int column = 1;
				workSheet.Cells[row, column].Value = "Mã số thuế";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Khách hàng";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Huyện";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Xã";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Điện thoại";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Địa chỉ";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Nhân viên";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Năm";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Doanh thu";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 01";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 02";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 03";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 04";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 05";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 06";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 07";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 08";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 09";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 10";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 11";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Tháng 12";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				row = row + 1;
				foreach (Report item in list)
				{
					workSheet.Cells[row, 1].Value = item.Code;
					workSheet.Cells[row, 2].Value = item.Name;
					workSheet.Cells[row, 3].Value = item.HuyenName;
					workSheet.Cells[row, 4].Value = item.XaName;
					workSheet.Cells[row, 5].Value = item.DienThoai;
					workSheet.Cells[row, 6].Value = item.DiaChi;
					workSheet.Cells[row, 7].Value = item.NhanVien;
					workSheet.Cells[row, 8].Value = item.Year;
					try
					{
						workSheet.Cells[row, 9].Value = item.DoanhThu.Value.ToString("N0");
						workSheet.Cells[row, 9].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 10].Value = item.DoanhThu01.Value.ToString("N0");
						workSheet.Cells[row, 10].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 11].Value = item.DoanhThu02.Value.ToString("N0");
						workSheet.Cells[row, 11].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 12].Value = item.DoanhThu03.Value.ToString("N0");
						workSheet.Cells[row, 12].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 12].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 13].Value = item.DoanhThu04.Value.ToString("N0");
						workSheet.Cells[row, 13].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 13].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 14].Value = item.DoanhThu05.Value.ToString("N0");
						workSheet.Cells[row, 14].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 15].Value = item.DoanhThu06.Value.ToString("N0");
						workSheet.Cells[row, 15].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 16].Value = item.DoanhThu07.Value.ToString("N0");
						workSheet.Cells[row, 16].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 16].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 17].Value = item.DoanhThu08.Value.ToString("N0");
						workSheet.Cells[row, 17].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 17].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 18].Value = item.DoanhThu09.Value.ToString("N0");
						workSheet.Cells[row, 18].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 18].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 19].Value = item.DoanhThu10.Value.ToString("N0");
						workSheet.Cells[row, 19].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 20].Value = item.DoanhThu11.Value.ToString("N0");
						workSheet.Cells[row, 20].Style.Numberformat.Format = "#";
						workSheet.Cells[row, 20].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
					}
					catch (Exception e)
					{
					}
					try
					{
						workSheet.Cells[row, 21].Value = item.DoanhThu12.Value.ToString("N0");
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

						workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

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

		private void InitializationExcelDoanhNghiep(List<DoanhNghiep> list, MemoryStream streamExport)
		{
			using (var package = new ExcelPackage(streamExport))
			{
				var workSheet = package.Workbook.Worksheets.Add("Sheet1");
				int row = 1;
				int column = 1;
				workSheet.Cells[row, column].Value = "Mã số thuế";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "KHACHHANG_ID";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Khách hàng";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Điện thoại";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Huyện";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Địa chỉ";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;



				List<Huyen> listHuyen = _HuyenBusiness.GetAllToList();
				row = row + 1;
				foreach (DoanhNghiep item in list)
				{
					workSheet.Cells[row, 1].Value = item.Code;
					workSheet.Cells[row, 2].Value = item.KHACHHANG_ID;
					workSheet.Cells[row, 3].Value = item.Name;
					workSheet.Cells[row, 4].Value = item.DienThoai;
					try
					{
						workSheet.Cells[row, 5].Value = listHuyen.Where(huyen => huyen.ID == item.HuyenID).FirstOrDefault().Name;
					}
					catch (Exception e)
					{
						workSheet.Cells[row, 5].Value = item.HuyenID;
					}

					workSheet.Cells[row, 6].Value = item.DiaChi;

					for (int i = 1; i <= column; i++)
					{
						workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
						workSheet.Cells[row, i].Style.Font.Size = 11;
						workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

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

		private void InitializationExcelReportCA(List<Report> list, MemoryStream streamExport)
		{
			using (var package = new ExcelPackage(streamExport))
			{
				var workSheet = package.Workbook.Worksheets.Add("Sheet1");
				int row = 1;
				int column = 1;
				workSheet.Cells[row, column].Value = "Huyện";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Doanh nghiệp";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "UserName";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chứng thư";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Chứng thư cũ";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Hiệu lực";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Hết hạn";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Nhân viên";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Yêu cầu";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Duyệt";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Hoàn thành";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Kết luận";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Hợp đồng";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Phiếu đăng ký";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "CCCD/HC";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Giấy phép kinh doanh";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Biên bản nghiệm thu";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Hoá đơn";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				column = column + 1;
				workSheet.Cells[row, column].Value = "Ghi chú";
				workSheet.Cells[row, column].Style.Font.Bold = true;
				workSheet.Cells[row, column].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



				workSheet.Cells[row, column].Style.Font.Name = "Times New Roman";
				workSheet.Cells[row, column].Style.Font.Size = 11;
				workSheet.Cells[row, column].Style.Border.Top.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Left.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Right.Style = ExcelBorderStyle.Thin;

				workSheet.Cells[row, column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


				row = row + 1;
				foreach (Report item in list)
				{
					workSheet.Cells[row, 1].Value = item.HuyenName;
					workSheet.Cells[row, 2].Value = item.DoanhNghiepName;
					workSheet.Cells[row, 3].Value = item.UserName;
					workSheet.Cells[row, 4].Value = item.SoChungThu;
					workSheet.Cells[row, 5].Value = item.SoChungThuCu;
					try
					{
						workSheet.Cells[row, 6].Value = item.NgayHieuLuc.Value.ToString("yyyy-MM-dd");
					}
					catch (Exception ex)
					{
						workSheet.Cells[row, 6].Value = "";
						string mes = ex.Message;
					}
					try
					{
						workSheet.Cells[row, 7].Value = item.NgayHetHan.Value.ToString("yyyy-MM-dd");
					}
					catch (Exception ex)
					{
						workSheet.Cells[row, 67].Value = "";
						string mes = ex.Message;
					}
					workSheet.Cells[row, 8].Value = item.NhanVienName;
					workSheet.Cells[row, 9].Value = item.TaiKhoanTaoYeuCau;
					workSheet.Cells[row, 10].Value = item.TaiKhoanDuyetYeuCau;
					workSheet.Cells[row, 11].Value = item.IsKetLuan;
					workSheet.Cells[row, 12].Value = item.KetLuan;
					workSheet.Cells[row, 13].Value = item.IsHopDong;
					workSheet.Cells[row, 14].Value = item.IsDonXinCapChungThuSo;
					workSheet.Cells[row, 15].Value = item.IsCCCD;
					workSheet.Cells[row, 16].Value = item.IsGiayPhepKinhDoanh;
					workSheet.Cells[row, 17].Value = item.IsBienBanNghiemThu;
					workSheet.Cells[row, 18].Value = item.IsHoaDon;
					workSheet.Cells[row, 19].Value = item.Note;


					for (int i = 1; i <= column; i++)
					{
						workSheet.Cells[row, i].Style.Font.Name = "Times New Roman";
						workSheet.Cells[row, i].Style.Font.Size = 11;
						workSheet.Cells[row, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;

						workSheet.Cells[row, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

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
