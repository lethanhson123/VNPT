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
		private readonly IDoanhNghiepDichVuCABusiness _DoanhNghiepDichVuCABusiness;
		public EmailController(IWebHostEnvironment WebHostEnvironment
			, INhanVienTokenBusiness NhanVienTokenBusiness
			, INhanVienTaiKhoanBusiness nhanVienTaiKhoanBusiness
			, INhanVienBusiness nhanVienBusiness
			, IDoanhNghiepBusiness doanhNghiepBusiness
			, IPhongBanBusiness phongBanBusiness
			, IEmailConfigBusiness EmailConfigBusiness
			, IDoanhNghiepDichVuCABusiness DoanhNghiepDichVuCABusiness
			) : base(NhanVienTokenBusiness)
		{
			_WebHostEnvironment = WebHostEnvironment;
			_NhanVienTokenBusiness = NhanVienTokenBusiness;
			_NhanVienTaiKhoanBusiness = nhanVienTaiKhoanBusiness;
			_NhanVienBusiness = nhanVienBusiness;
			_DoanhNghiepBusiness = doanhNghiepBusiness;
			_PhongBanBusiness = phongBanBusiness;
			_EmailConfigBusiness = EmailConfigBusiness;
			_DoanhNghiepDichVuCABusiness = DoanhNghiepDichVuCABusiness;
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
					if (emailConfig.IsMailBodyHtml == true)
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

        [HttpPost]
        [Route("AsyncHetHanDoanhNghiepDichVuCA2024")]
        public async Task<bool> AsyncHetHanDoanhNghiepDichVuCA2024()
        {
            bool result = GlobalHelper.InitializationBool;
            try
            {
                BaseParameter baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
                DoanhNghiepDichVuCA doanhNghiepDichVuCA = await _DoanhNghiepDichVuCABusiness.GetByIDAsync(baseParameter.ID);
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
                    if (emailConfig.IsMailBodyHtml == true)
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

        [HttpPost]
		[Route("AsyncThieuHoSoDoanhNghiepDichVuCA")]
		public async Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCA()
		{
			bool result = GlobalHelper.InitializationBool;
			try
			{
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
					if (emailConfig.IsMailBodyHtml == true)
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
				List<NhanVien> listNhanVien = await _NhanVienBusiness.GetByActiveToListAsync(true);

				foreach (NhanVien nhanVien in listNhanVien)
				{
					if (!string.IsNullOrEmpty(nhanVien.Email))
					{
						List<DoanhNghiepDichVuCA> listDoanhNghiepDichVuCA = await _DoanhNghiepDichVuCABusiness.GetByNhanVienIDToListAsync(nhanVien.ID);
						if (listDoanhNghiepDichVuCA.Count > 0)
						{
							string contentHTML = GlobalHelper.InitializationString;
							var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "DoanhNghiepDichVuCAThieuHoSo.html");
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
							string pageTitle = "VNPT-CA & SMART-CA";
							contentHTML = contentHTML.Replace("[PageTitle]", pageTitle);
							StringBuilder contentDoanhNghiepDichVuCA = new StringBuilder();
							foreach (DoanhNghiepDichVuCA doanhNghiepDichVuCA in listDoanhNghiepDichVuCA)
							{
								contentDoanhNghiepDichVuCA.AppendLine("<hr/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"Khách hàng: <b>" + doanhNghiepDichVuCA.Name + "</b>");
								contentDoanhNghiepDichVuCA.AppendLine("<br/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"UserName: <b>" + doanhNghiepDichVuCA.UserName + "</b>");
								contentDoanhNghiepDichVuCA.AppendLine("<br/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"SERIAL: <b>" + doanhNghiepDichVuCA.SoChungThu + "</b>");
							}
							contentHTML = contentHTML.Replace("[DoanhNghiep]", contentDoanhNghiepDichVuCA.ToString());
							contentHTML = contentHTML.Replace("[NhanVienName]", nhanVien.Name);
							mail.Content = contentHTML;
							mail.MailTo = nhanVien.Email;
							//mail.MailTo = "lethanhson123@gmail.com";
							mail.Subject = "CÁNH BÁO HỒ SƠ "+ pageTitle + " SAI QUY ĐỊNH - " + nhanVien.Name + " - " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
							MailHelper.SendMail(mail);
						}
					}
				}


			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}

			return result;
		}

		[HttpPost]
		[Route("AsyncThieuHoSoDoanhNghiepDichVuCAIsSmartCA")]
		public async Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCAIsSmartCA()
		{
			bool isSmartCA = JsonConvert.DeserializeObject<bool>(Request.Form["data"]);
			bool result = GlobalHelper.InitializationBool;
			try
			{
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
					if (emailConfig.IsMailBodyHtml == true)
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
				List<NhanVien> listNhanVien = await _NhanVienBusiness.GetByActiveToListAsync(true);

				foreach (NhanVien nhanVien in listNhanVien)
				{
					if (!string.IsNullOrEmpty(nhanVien.Email))
					{
						List<DoanhNghiepDichVuCA> listDoanhNghiepDichVuCA = await _DoanhNghiepDichVuCABusiness.GetByNhanVienIDAndIsSmartCAToListAsync(nhanVien.ID, isSmartCA);
						if (listDoanhNghiepDichVuCA.Count > 0)
						{
							string contentHTML = GlobalHelper.InitializationString;
							var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "DoanhNghiepDichVuCAThieuHoSo.html");
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
							string pageTitle = "VNPT-CA & SMART-CA";
							if (isSmartCA == true)
							{
								pageTitle = "SMART-CA";
							}
							else
							{
								pageTitle = "VNPT-CA";
							}
							contentHTML = contentHTML.Replace("[PageTitle]", pageTitle);
							StringBuilder contentDoanhNghiepDichVuCA = new StringBuilder();
							foreach (DoanhNghiepDichVuCA doanhNghiepDichVuCA in listDoanhNghiepDichVuCA)
							{
								contentDoanhNghiepDichVuCA.AppendLine("<hr/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"Khách hàng: <b>" + doanhNghiepDichVuCA.Name + "</b>");
								contentDoanhNghiepDichVuCA.AppendLine("<br/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"UserName: <b>" + doanhNghiepDichVuCA.UserName + "</b>");
								contentDoanhNghiepDichVuCA.AppendLine("<br/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"SERIAL: <b>" + doanhNghiepDichVuCA.SoChungThu + "</b>");
							}
							contentHTML = contentHTML.Replace("[DoanhNghiep]", contentDoanhNghiepDichVuCA.ToString());
							contentHTML = contentHTML.Replace("[NhanVienName]", nhanVien.Name);

							mail.Content = contentHTML;
							mail.MailTo = nhanVien.Email;
							//mail.MailTo = "lethanhson123@gmail.com";
							mail.Subject = "CÁNH BÁO HỒ SƠ "+ pageTitle + " SAI QUY ĐỊNH - " + nhanVien.Name + " - " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
							MailHelper.SendMail(mail);
						}
					}
				}


			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}

			return result;
		}

		[HttpPost]
		[Route("AsyncThieuHoSoDoanhNghiepDichVuCAByYearAndMonth")]
		public async Task<bool> AsyncThieuHoSoDoanhNghiepDichVuCAByYearAndMonth(string data)
		{
			bool result = GlobalHelper.InitializationBool;

			try
			{
				int year = GlobalHelper.InitializationDateTime.Year;
				int month = GlobalHelper.InitializationDateTime.Month;

				if (!string.IsNullOrEmpty(data))
				{
					if (data.Split('_').Length > 0)
					{
						year = int.Parse(data.Split('_')[0]);
					}
					if (data.Split('_').Length > 1)
					{
						month = int.Parse(data.Split('_')[1]);
					}
				}

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
					if (emailConfig.IsMailBodyHtml == true)
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


				mail.Subject = "CÁNH BÁO HỒ SƠ SAI QUY ĐỊNH - " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
				string contentHTML = GlobalHelper.InitializationString;
				var physicalPathRead = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Download, "DoanhNghiepDichVuCAThieuHoSo.html");
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

				List<NhanVien> listNhanVien = await _NhanVienBusiness.GetByActiveToListAsync(true);

				foreach (NhanVien nhanVien in listNhanVien)
				{
					if (!string.IsNullOrEmpty(nhanVien.Email))
					{

						List<DoanhNghiepDichVuCA> listDoanhNghiepDichVuCA = await _DoanhNghiepDichVuCABusiness.GetByNhanVienIDAndYearAndMonthToListAsync(nhanVien.ID, year, month);
						if (listDoanhNghiepDichVuCA.Count > 0)
						{
							StringBuilder contentDoanhNghiepDichVuCA = new StringBuilder();
							foreach (DoanhNghiepDichVuCA doanhNghiepDichVuCA in listDoanhNghiepDichVuCA)
							{
								contentDoanhNghiepDichVuCA.AppendLine("<hr/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"Khách hàng: <b>" + doanhNghiepDichVuCA.Name + "</b>");
								contentDoanhNghiepDichVuCA.AppendLine("<br/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"UserName: <b>" + doanhNghiepDichVuCA.UserName + "</b>");
								contentDoanhNghiepDichVuCA.AppendLine("<br/>");
								contentDoanhNghiepDichVuCA.AppendLine(@"SERIAL: <b>" + doanhNghiepDichVuCA.SoChungThu + "</b>");
							}
							contentHTML = contentHTML.Replace("[DoanhNghiep]", contentDoanhNghiepDichVuCA.ToString());
							contentHTML = contentHTML.Replace("[NhanVienName]", nhanVien.Name);
							mail.Content = contentHTML;
							mail.MailTo = nhanVien.Email;
							MailHelper.SendMail(mail);
						}
					}
				}


			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}

			return result;
		}

        [HttpGet]
        [Route("EmailTest")]
        public async Task<bool> EmailTest()
        {
            bool result = GlobalHelper.InitializationBool;
			try
			{
                Helper.Model.Mail mail = new Helper.Model.Mail();
                mail.MailFrom = "dungnv.vtu@vnpt.vn";
                mail.UserName = "dungnv.vtu@vnpt.vn";
                mail.Password = "Tcdn@1234";
                mail.SMTPPort = 587;
                mail.SMTPServer = "email.vnpt.vn";
                mail.IsMailBodyHtml = GlobalHelper.IsMailBodyHtml;
                mail.IsMailUsingSSL = GlobalHelper.IsMailUsingSSL;
                mail.Display = GlobalHelper.MasterEmailDisplay;
                mail.Subject = "Email test - " + GlobalHelper.InitializationDateTime.ToString("dd/MM/yyyy HH:mm:ss");
                mail.Content = "SOHU";
                mail.MailTo = "lethanhson123@gmail.com";
                MailHelper.SendMail(mail);
            }
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
           
            return result;
        }

        [HttpGet]
        [Route("GetAsyncHetHanDoanhNghiepDichVuCA2024")]
        public async Task<bool> GetAsyncHetHanDoanhNghiepDichVuCA2024(long ID)
        {
            bool result = GlobalHelper.InitializationBool;
            try
            {                
                DoanhNghiepDichVuCA doanhNghiepDichVuCA = await _DoanhNghiepDichVuCABusiness.GetByIDAsync(ID);
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
                    if (emailConfig.IsMailBodyHtml == true)
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


