namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class HuyenController : BaseController<Huyen, IHuyenBusiness>
	{
		private readonly IHuyenBusiness _HuyenBusiness;
		public HuyenController(IHuyenBusiness HuyenBusiness) : base(HuyenBusiness)
		{
			_HuyenBusiness = HuyenBusiness;
		}
		[HttpPost]
		[Route("GetSQLByNhanVienID_ActiveAsync")]
		public virtual async Task<List<Huyen>> GetSQLByNhanVienID_ActiveAsync()
		{
			List<Huyen> result = new List<Huyen>();
			try
			{
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["nhanVienID"]);
				result = await _HuyenBusiness.GetSQLByNhanVienID_ActiveAsync(nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
	}
}
