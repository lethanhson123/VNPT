using Business.Model;

namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class NhanVienController : BaseController<NhanVien, INhanVienBusiness>
	{
		private readonly INhanVienBusiness _NhanVienBusiness;
		private readonly IWebHostEnvironment _WebHostEnvironment;
		public NhanVienController(INhanVienBusiness NhanVienBusiness, IWebHostEnvironment WebHostEnvironment) : base(NhanVienBusiness)
		{
			_NhanVienBusiness = NhanVienBusiness;
			_WebHostEnvironment = WebHostEnvironment;
		}
		//[HttpPost]
		//[Route("SetMatKhau")]
		//public async Task<int> SetMatKhauAsync()
		//{
		//	List<NhanVien> list = await _NhanVienBusiness.GetAllToListAsync();
		//	foreach (NhanVien nhanVien in list)
		//	{
		//		nhanVien.MatKhau = "vnpt@123";
		//		await _NhanVienBusiness.SaveAsync(nhanVien);
		//	}
		//	return 0;
		//}

		[HttpPost]
		[Route("SaveAndUploadFileAsync")]
		public async Task<NhanVien> SaveAndUploadFileAsync()
		{
			NhanVien model = JsonConvert.DeserializeObject<NhanVien>(Request.Form["data"]);
			try
			{
				if (model.Description == GlobalHelper.Token)
				{
					model.Description = GlobalHelper.APISuccessMessage;
					if (Request.Form.Files.Count > 0)
					{
						var file = Request.Form.Files[0];
						if (file == null || file.Length == 0)
						{
						}
						if (file != null)
						{
							string fileExtension = Path.GetExtension(file.FileName);
							model.Note = model.ID + "_" + GlobalHelper.InitializationDateTimeCode0001 + fileExtension;
							string folderPath = Path.Combine(_WebHostEnvironment.WebRootPath, GlobalHelper.Image, model.GetType().Name);
							bool isFolderExists = System.IO.Directory.Exists(folderPath);
							if (!isFolderExists)
							{
								System.IO.Directory.CreateDirectory(folderPath);
							}
							var physicalPath = Path.Combine(folderPath, model.Note);
							using (var stream = new FileStream(physicalPath, FileMode.Create))
							{
								file.CopyTo(stream);
								model.Note = GlobalHelper.APISite + GlobalHelper.Image + "/" + model.GetType().Name + "/" + model.Note;
							}
						}
					}
					await _NhanVienBusiness.SaveAsync(model);
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

			return model;
		}
		[HttpPost]
		[Route("GetByIDStringAsync")]
		public async Task<NhanVien> GetByIDStringAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			NhanVien result = new NhanVien();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					if (!string.IsNullOrEmpty(baseParameter.IDString))
					{
						baseParameter.IDString = GlobalHelper.InitializationURLCode(baseParameter.IDString);
						baseParameter.ID = int.Parse(baseParameter.IDString);
						result = await _NhanVienBusiness.GetByIDAsync(baseParameter.ID);
					}
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
			result.Description = baseParameter.APIMessage;
			return result;
		}
		[HttpPost]
		[Route("AuthenticationAsync")]
		public virtual async Task<NhanVien> AuthenticationAsync()
		{
			NhanVien result = new NhanVien();
			try
			{
				NhanVien model = JsonConvert.DeserializeObject<NhanVien>(Request.Form["data"]);
				if (model.Description == GlobalHelper.Token)
				{
					model.Description = GlobalHelper.APISuccessMessage;
					result = await _NhanVienBusiness.AuthenticationAsync(model);
				}
				else
				{
					model.Description = GlobalHelper.APIErrorMessage;
				}
			}
			catch (Exception ex)
			{
				result.Description = ex.Message;
			}
			return result;
		}
	}
}
