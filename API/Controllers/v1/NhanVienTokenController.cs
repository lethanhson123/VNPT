namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class NhanVienTokenController : BaseController<NhanVienToken, INhanVienTokenBusiness>
	{
		private readonly INhanVienTokenBusiness _NhanVienTokenBusiness;
		public NhanVienTokenController(INhanVienTokenBusiness NhanVienTokenBusiness) : base(NhanVienTokenBusiness)
		{
			_NhanVienTokenBusiness = NhanVienTokenBusiness;
		}
		[HttpPost]
		[Route("AuthenticationAsync")]
		public virtual async Task<NhanVienToken> AuthenticationAsync()
		{
			NhanVienToken result = new NhanVienToken();
			try
			{
				NhanVienToken model = JsonConvert.DeserializeObject<NhanVienToken>(Request.Form["data"]);
				result = await _NhanVienTokenBusiness.AuthenticationAsync(model);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
		[HttpPost]
		[Route("GetByTokenAsync")]
		public virtual async Task<NhanVienToken> GetByTokenAsync()
		{
			NhanVienToken result = new NhanVienToken();
			try
			{
				string token = JsonConvert.DeserializeObject<string>(Request.Form["token"]);
				result = await _NhanVienTokenBusiness.GetByTokenAsync(token);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
	}
}

