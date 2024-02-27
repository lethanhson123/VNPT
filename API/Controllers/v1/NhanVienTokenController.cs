using Business.Model;

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
				if (model.Description == GlobalHelper.Token)
				{
					model.Description = GlobalHelper.APISuccessMessage;
					result = await _NhanVienTokenBusiness.AuthenticationAsync(model);
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
		[HttpPost]
		[Route("GetByTokenAsync")]
		public virtual async Task<NhanVienToken> GetByTokenAsync()
		{
			NhanVienToken result = new NhanVienToken();
			BaseParameter baseParameter = new BaseParameter();
			try
			{			
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _NhanVienTokenBusiness.GetByTokenAsync(baseParameter.Code);
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
			return result;
		}
	}
}

