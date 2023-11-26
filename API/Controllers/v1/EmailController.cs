using Data.Model;
using Microsoft.AspNetCore.Hosting;


namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class EmailController : BaseController<NhanVienToken, INhanVienTokenBusiness>
	{
		private readonly IWebHostEnvironment _WebHostEnvironment;
		private readonly INhanVienTokenBusiness _NhanVienTokenBusiness;
		private readonly INhanVienBusiness _NhanVienBusiness;
		public EmailController(IWebHostEnvironment WebHostEnvironment
			, INhanVienTokenBusiness NhanVienTokenBusiness
			, INhanVienBusiness nhanVienBusiness
			) : base(NhanVienTokenBusiness)
		{
			_WebHostEnvironment = WebHostEnvironment;
			_NhanVienTokenBusiness = NhanVienTokenBusiness;
			_NhanVienBusiness = nhanVienBusiness;
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
	}
}

