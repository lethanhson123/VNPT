using Business.Model;
using Helper;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class DoanhNghiepDichVuCAController : BaseController<DoanhNghiepDichVuCA, IDoanhNghiepDichVuCABusiness>
	{
		private readonly IDoanhNghiepDichVuCABusiness _DoanhNghiepDichVuCABusiness;
		private readonly IWebHostEnvironment _WebHostEnvironment;
		public DoanhNghiepDichVuCAController(IDoanhNghiepDichVuCABusiness DoanhNghiepDichVuCABusiness, IWebHostEnvironment WebHostEnvironment) : base(DoanhNghiepDichVuCABusiness)
		{
			_DoanhNghiepDichVuCABusiness = DoanhNghiepDichVuCABusiness;
			_WebHostEnvironment = WebHostEnvironment;
		}
		[HttpPost]
		[Route("SaveAndUploadFilesAsync")]
		public async Task<DoanhNghiepDichVuCA> SaveAndUploadFilesAsync()
		{
			DoanhNghiepDichVuCA model = JsonConvert.DeserializeObject<DoanhNghiepDichVuCA>(Request.Form["data"]);
			try
			{
				if (model.Description == GlobalHelper.Token)
				{
					model.Description = GlobalHelper.APISuccessMessage;
					if (Request.Form.Files.Count > 0)
					{
						string folderPath = Path.Combine(_WebHostEnvironment.WebRootPath, model.GetType().Name);
						bool isFolderExists = System.IO.Directory.Exists(folderPath);
						if (!isFolderExists)
						{
							System.IO.Directory.CreateDirectory(folderPath);
						}
						if (Request.Form.Files.Count > 0)
						{
							var file = Request.Form.Files[0];
							if (file == null || file.Length == 0)
							{
							}
							if (file != null)
							{
								string fileExtension = Path.GetExtension(file.FileName);
								if (fileExtension.Contains("txt") == false)
								{
									model.HopDong = model.SoChungThu + "_HopDong_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
									var physicalPath = Path.Combine(folderPath, model.HopDong);
									using (var stream = new FileStream(physicalPath, FileMode.Create))
									{
										file.CopyTo(stream);
									}
									if (!string.IsNullOrEmpty(model.HopDong))
									{
										model.HopDong = GlobalHelper.APISite + model.GetType().Name + "/" + model.HopDong;
									}
								}
							}
						}
						if (Request.Form.Files.Count > 1)
						{
							var file = Request.Form.Files[1];
							if (file == null || file.Length == 0)
							{
							}
							if (file != null)
							{
								string fileExtension = Path.GetExtension(file.FileName);
								if (fileExtension.Contains("txt") == false)
								{
									model.DonXinCapChungThuSo = model.SoChungThu + "_DonXinCapChungThuSo_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
									var physicalPath = Path.Combine(folderPath, model.DonXinCapChungThuSo);
									using (var stream = new FileStream(physicalPath, FileMode.Create))
									{
										file.CopyTo(stream);
									}
									if (!string.IsNullOrEmpty(model.DonXinCapChungThuSo))
									{
										model.DonXinCapChungThuSo = GlobalHelper.APISite + model.GetType().Name + "/" + model.DonXinCapChungThuSo;
									}
								}
							}
						}
						if (Request.Form.Files.Count > 2)
						{
							var file = Request.Form.Files[2];
							if (file == null || file.Length == 0)
							{
							}
							if (file != null)
							{
								string fileExtension = Path.GetExtension(file.FileName);
								if (fileExtension.Contains("txt") == false)
								{
									model.GiayPhepKinhDoanh = model.SoChungThu + "_GiayPhepKinhDoanh_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
									var physicalPath = Path.Combine(folderPath, model.GiayPhepKinhDoanh);
									using (var stream = new FileStream(physicalPath, FileMode.Create))
									{
										file.CopyTo(stream);
									}
									if (!string.IsNullOrEmpty(model.GiayPhepKinhDoanh))
									{
										model.GiayPhepKinhDoanh = GlobalHelper.APISite + model.GetType().Name + "/" + model.GiayPhepKinhDoanh;
									}
								}
							}
						}
						if (Request.Form.Files.Count > 3)
						{
							var file = Request.Form.Files[3];
							if (file == null || file.Length == 0)
							{
							}
							if (file != null)
							{
								string fileExtension = Path.GetExtension(file.FileName);
								if (fileExtension.Contains("txt") == false)
								{
									model.BienBanNghiemThu = model.SoChungThu + "_BienBanNghiemThu_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
									var physicalPath = Path.Combine(folderPath, model.BienBanNghiemThu);
									using (var stream = new FileStream(physicalPath, FileMode.Create))
									{
										file.CopyTo(stream);
									}
									if (!string.IsNullOrEmpty(model.BienBanNghiemThu))
									{
										model.BienBanNghiemThu = GlobalHelper.APISite + model.GetType().Name + "/" + model.BienBanNghiemThu;
									}
								}
							}
						}
						if (Request.Form.Files.Count > 4)
						{
							var file = Request.Form.Files[4];
							if (file == null || file.Length == 0)
							{
							}
							if (file != null)
							{
								string fileExtension = Path.GetExtension(file.FileName);
								if (fileExtension.Contains("txt") == false)
								{
									model.HoaDon = model.SoChungThu + "_HoaDon_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
									var physicalPath = Path.Combine(folderPath, model.HoaDon);
									using (var stream = new FileStream(physicalPath, FileMode.Create))
									{
										file.CopyTo(stream);
									}
									if (!string.IsNullOrEmpty(model.HoaDon))
									{
										model.HoaDon = GlobalHelper.APISite + model.GetType().Name + "/" + model.HoaDon;
									}
								}
							}
						}
						if (Request.Form.Files.Count > 5)
						{
							var file = Request.Form.Files[5];
							if (file == null || file.Length == 0)
							{
							}
							if (file != null)
							{
								string fileExtension = Path.GetExtension(file.FileName);
								if (fileExtension.Contains("txt") == false)
								{
									model.CCCD = model.SoChungThu + "_CCCD_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
									var physicalPath = Path.Combine(folderPath, model.CCCD);
									using (var stream = new FileStream(physicalPath, FileMode.Create))
									{
										file.CopyTo(stream);
									}
									if (!string.IsNullOrEmpty(model.CCCD))
									{
										model.CCCD = GlobalHelper.APISite + model.GetType().Name + "/" + model.CCCD;
									}
								}
							}
						}
					}
				}
				else
				{
					model.Description = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception e)
			{
				model.Description = e.Message;
			}
			await _DoanhNghiepDichVuCABusiness.SaveAsync(model);
			return model;
		}

		[HttpPost]
		[Route("Save001Async")]
		public virtual async Task<DoanhNghiepDichVuCA> Save001Async()
		{
			DoanhNghiepDichVuCA result = new DoanhNghiepDichVuCA();
			try
			{
				result = JsonConvert.DeserializeObject<DoanhNghiepDichVuCA>(Request.Form["data"]);
				if (result.Description == GlobalHelper.Token)
				{
					result.Description = GlobalHelper.APISuccessMessage;
					await _DoanhNghiepDichVuCABusiness.Save001Async(result);
				}
				else
				{
					result.Description = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				result.Description = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("AsyncThieuHoSoDoanhNghiepDichVuCA")]
		public virtual async Task<BaseParameter> AsyncThieuHoSoDoanhNghiepDichVuCA()
		{
			BaseParameter baseParameter = new BaseParameter();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					await _DoanhNghiepDichVuCABusiness.AsyncThieuHoSoDoanhNghiepDichVuCA();
				}
				else
				{
					baseParameter.APIMessage = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				baseParameter.APIMessage = ex.Message;
			}
			return baseParameter;
		}
		[HttpPost]
		[Route("AsyncThieuHoSoDoanhNghiepDichVuCAIsSmartCA")]
		public virtual async Task<BaseParameter> AsyncThieuHoSoDoanhNghiepDichVuCAIsSmartCA()
		{
			BaseParameter baseParameter = new BaseParameter();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					await _DoanhNghiepDichVuCABusiness.AsyncThieuHoSoDoanhNghiepDichVuCAIsSmartCA(baseParameter.IsSmartCA.Value);
				}
				else
				{
					baseParameter.APIMessage = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				baseParameter.APIMessage = ex.Message;
			}
			return baseParameter;
		}
		[HttpPost]
		[Route("AsyncThieuHoSoDoanhNghiepDichVuCAByYearAndMonth")]
		public virtual async Task<BaseParameter> AsyncThieuHoSoDoanhNghiepDichVuCAByYearAndMonth()
		{
			BaseParameter baseParameter = new BaseParameter();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					await _DoanhNghiepDichVuCABusiness.AsyncThieuHoSoDoanhNghiepDichVuCAByYearAndMonth(baseParameter.Year.Value, baseParameter.Month.Value);
				}
				else
				{
					baseParameter.APIMessage = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				baseParameter.APIMessage = ex.Message;
			}
			return baseParameter;
		}

		[HttpPost]
		[Route("DongBoDuLieuAsync")]
		public virtual async Task<BaseParameter> DongBoDuLieuAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					await _DoanhNghiepDichVuCABusiness.DongBoDuLieuAsync();
				}
				else
				{
					baseParameter.APIMessage = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				baseParameter.APIMessage = ex.Message;
			}
			return baseParameter;
		}
		[HttpGet]
		[Route("DongBoDuLieuNoteAsync")]
		public virtual async Task<BaseParameter> DongBoDuLieuNoteAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					await _DoanhNghiepDichVuCABusiness.DongBoDuLieuNoteAsync();
				}
				else
				{
					baseParameter.APIMessage = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				baseParameter.APIMessage = ex.Message;
			}
			return baseParameter;
		}
	}
}
