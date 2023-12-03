using Data.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;


namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class EmailController : BaseController<NhanVienToken, INhanVienTokenBusiness>
	{
		private readonly IWebHostEnvironment _WebHostEnvironment;
		private readonly INhanVienTokenBusiness _NhanVienTokenBusiness;
		private readonly INhanVienTaiKhoanBusiness _NhanVienTaiKhoanBusiness;
		private readonly INhanVienBusiness _NhanVienBusiness;
		private readonly IDoanhNghiepBusiness _DoanhNghiepBusiness;
		private readonly IPhongBanBusiness _PhongBanBusiness;
		private readonly IEmailConfigBusiness _EmailConfigBusiness;
		public EmailController(IWebHostEnvironment WebHostEnvironment
			, INhanVienTokenBusiness NhanVienTokenBusiness
			, INhanVienTaiKhoanBusiness nhanVienTaiKhoanBusiness
			, INhanVienBusiness nhanVienBusiness
			, IDoanhNghiepBusiness doanhNghiepBusiness
			, IPhongBanBusiness phongBanBusiness
			, IEmailConfigBusiness EmailConfigBusiness
			) : base(NhanVienTokenBusiness)
		{
			_WebHostEnvironment = WebHostEnvironment;
			_NhanVienTokenBusiness = NhanVienTokenBusiness;
			_NhanVienTaiKhoanBusiness = nhanVienTaiKhoanBusiness;
			_NhanVienBusiness = nhanVienBusiness;
			_DoanhNghiepBusiness = doanhNghiepBusiness;
			_PhongBanBusiness = phongBanBusiness;
			_EmailConfigBusiness = EmailConfigBusiness;
		}
		[HttpPost]
		[Route("AsyncNhanVienToken")]
		public async Task<bool> AsyncNhanVienToken(NhanVienToken nhanVienToken)
		{
			bool result = GlobalHelper.InitializationBool;
			Helper.Model.Mail mail = new Helper.Model.Mail();
			mail.MailFrom = GlobalHelper.MasterEmailUser;
			mail.UserName = GlobalHelper.MasterEmailUser;
			mail.Password = GlobalHelper.MasterEmailPassword;
			mail.SMTPPort = GlobalHelper.SMTPPort;
			mail.SMTPServer = GlobalHelper.SMTPServer;
			mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
			mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
			mail.Display = GlobalHelper.MasterEmailDisplay;
			mail.Subject = "Xác thực đăng nhập - " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
			string contentHTML = GlobalHelper.InitializationString;
			var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "NhanVienToken.html");
			using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
			{
				using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
				{
					contentHTML = r.ReadToEnd();
				}
			}
			contentHTML = contentHTML.Replace("[OTP001]", nhanVienToken.OTP001);
			contentHTML = contentHTML.Replace("[Year]", GlobalHelper.InitializationDateTime.Year.ToString());
			contentHTML = contentHTML.Replace("[Month]", GlobalHelper.InitializationDateTime.Month.ToString());
			contentHTML = contentHTML.Replace("[Day]", GlobalHelper.InitializationDateTime.Day.ToString());
			mail.Content = contentHTML;
			NhanVien thanhVien = await _NhanVienBusiness.GetByIDAsync(nhanVienToken.ParentID.Value);
			if (thanhVien != null)
			{
				if (!string.IsNullOrEmpty(thanhVien.Email))
				{
					mail.MailTo = thanhVien.Email;
					MailHelper.SendMail(mail);
				}
			}
			return result;
		}
		[HttpPost]
		[Route("AsyncHetHanDoanhNghiepDichVuCA")]
		public async Task<bool> AsyncHetHanDoanhNghiepDichVuCA(DoanhNghiepDichVuCA doanhNghiepDichVuCA)
		{
			bool result = GlobalHelper.InitializationBool;

			try
			{
				var diffOfDates = doanhNghiepDichVuCA.NgayHetHan.Value.Subtract(GlobalHelper.InitializationDateTime);
				Helper.Model.Mail mail = new Helper.Model.Mail();

				EmailConfig emailConfig = await _EmailConfigBusiness.GetByCondition(item => item.Active == true).OrderBy(item => item.SortOrder).FirstOrDefaultAsync();
				if (emailConfig != null)
				{
					mail.MailFrom = emailConfig.MasterEmailUser;
					mail.UserName = emailConfig.MasterEmailUser;
					mail.Password = emailConfig.MasterEmailPassword;
					mail.SMTPPort = emailConfig.SMTPPort.Value;
					mail.SMTPServer = emailConfig.SMTPServer;
					mail.IsMailBodyHtml = 0;
					if (emailConfig.IsMailBodyHtml==true)
					{
						mail.IsMailBodyHtml = 1;
					}
					mail.IsMailUsingSSL = 0;
					if (emailConfig.IsMailUsingSSL == true)
					{
						mail.IsMailUsingSSL = 1;
					}					
					mail.Display = emailConfig.MasterEmailDisplay;
				}
				else
				{
					mail.MailFrom = GlobalHelper.MasterEmailUser;
					mail.UserName = GlobalHelper.MasterEmailUser;
					mail.Password = GlobalHelper.MasterEmailPassword;
					mail.SMTPPort = GlobalHelper.SMTPPort;
					mail.SMTPServer = GlobalHelper.SMTPServer;
					mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
					mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
					mail.Display = GlobalHelper.MasterEmailDisplay;
				}


				mail.Subject = "Thông báo về dịch vụ chữ ký số CA - " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
				string contentHTML = GlobalHelper.InitializationString;
				var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "DoanhNghiepDichVuCAHetHan.html");
				using (FileStream fs = new FileStream(physicalPathRead, FileMode.Open))
				{
					using (StreamReader r = new StreamReader(fs, Encoding.UTF8))
					{
						contentHTML = r.ReadToEnd();
					}
				}

				contentHTML = contentHTML.Replace("[Year]", GlobalHelper.InitializationDateTime.Year.ToString());
				contentHTML = contentHTML.Replace("[Month]", GlobalHelper.InitializationDateTime.Month.ToString());
				contentHTML = contentHTML.Replace("[Day]", GlobalHelper.InitializationDateTime.Day.ToString());


				contentHTML = contentHTML.Replace("[ChungThuSo]", doanhNghiepDichVuCA.SoChungThu);
				contentHTML = contentHTML.Replace("[NgayHetHan]", doanhNghiepDichVuCA.NgayHetHan.Value.ToString("dd/MM/yyyy"));
				string note = GlobalHelper.InitializationString;
				if (doanhNghiepDichVuCA.NgayHetHan <= GlobalHelper.InitializationDateTime)
				{
					note = "(Đã quá hạn)";
				}
				else
				{
					note = "(Còn " + diffOfDates.Days + " ngày nữa)";
				}
				contentHTML = contentHTML.Replace("[Note]", note);

				DoanhNghiep doanhNghiep = await _DoanhNghiepBusiness.GetByIDAsync(doanhNghiepDichVuCA.ParentID.Value);
				contentHTML = contentHTML.Replace("[DoanhNghiepName]", doanhNghiep.Name);
				contentHTML = contentHTML.Replace("[MaSoThue]", doanhNghiep.CodeCA);

				NhanVienTaiKhoan nhanVienTaiKhoan = await _NhanVienTaiKhoanBusiness.GetByCondition(item => item.Code == doanhNghiepDichVuCA.TaiKhoanTaoYeuCau).FirstOrDefaultAsync();
				NhanVien nhanVien = await _NhanVienBusiness.GetByIDAsync(nhanVienTaiKhoan.ParentID.Value);
				PhongBan phongBan = await _PhongBanBusiness.GetByIDAsync(nhanVien.ParentID.Value);

				contentHTML = contentHTML.Replace("[NhanVienName]", nhanVien.Name);
				contentHTML = contentHTML.Replace("[NhanVienDienThoai]", nhanVien.DienThoai);
				contentHTML = contentHTML.Replace("[NhanVienEmail]", nhanVien.Email);
				contentHTML = contentHTML.Replace("[PhongBanHangName]", phongBan.Name);

				mail.Content = contentHTML;
				if (!string.IsNullOrEmpty(doanhNghiepDichVuCA.Email))
				{
					mail.MailTo = doanhNghiepDichVuCA.Email;
					MailHelper.SendMail(mail);
				}
				if (string.IsNullOrEmpty(nhanVien.Email))
				{
					nhanVien.Email = "dungnv.vtu@vnpt.vn";
				}
				if (!string.IsNullOrEmpty(nhanVien.Email))
				{
					mail.MailTo = nhanVien.Email;
					MailHelper.SendMail(mail);
				}
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}

			return result;
		}
	}
}

