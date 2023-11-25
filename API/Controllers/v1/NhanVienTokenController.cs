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
	}
}

