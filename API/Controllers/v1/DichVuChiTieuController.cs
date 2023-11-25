namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class DichVuChiTieuController : BaseController<DichVuChiTieu, IDichVuChiTieuBusiness>
	{
		private readonly IDichVuChiTieuBusiness _DichVuChiTieuBusiness;		
		public DichVuChiTieuController(IDichVuChiTieuBusiness DichVuChiTieuBusiness) : base(DichVuChiTieuBusiness)
		{
			_DichVuChiTieuBusiness = DichVuChiTieuBusiness;			
		}
		[HttpPost]
		[Route("GetByNam_ThangToListAsync")]
		public virtual async Task<List<DichVuChiTieu>> GetByNam_ThangToListAsync()
		{
			List<DichVuChiTieu> result = new List<DichVuChiTieu>();
			try
			{
				int nam = JsonConvert.DeserializeObject<int>(Request.Form["nam"]);
				int thang = JsonConvert.DeserializeObject<int>(Request.Form["thang"]);
				result = await _DichVuChiTieuBusiness.GetByNam_ThangToListAsync(nam, thang);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
	}
}

