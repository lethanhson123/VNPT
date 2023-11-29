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
		[HttpPost]
		[Route("SaveAndUploadFileAsync")]
		public async Task<NhanVien> SaveAndUploadFileAsync()
		{
			NhanVien model = JsonConvert.DeserializeObject<NhanVien>(Request.Form["data"]);			
			try
			{
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
			}
			catch (Exception e)
			{
				string mes = e.Message;
			}
			await _NhanVienBusiness.SaveAsync(model);
			return model;
		}
		[HttpGet]
        [Route("GetByIDStringAsync")]
        public async Task<NhanVien> GetByIDStringAsync(string ID)
        {
            NhanVien result = new NhanVien();
            if (!string.IsNullOrEmpty(ID))
            {
                ID = GlobalHelper.InitializationURLCode(ID);
                result = await _NhanVienBusiness.GetByIDAsync(int.Parse(ID));
            }
            return result;
        }
		[HttpPost]
		[Route("AuthenticationAsync")]
		public virtual async Task<NhanVien> AuthenticationAsync()
		{
			NhanVien result = new NhanVien();
			try
			{
				NhanVien model= JsonConvert.DeserializeObject<NhanVien>(Request.Form["data"]);
				result = await _NhanVienBusiness.AuthenticationAsync(model);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
	}
}
