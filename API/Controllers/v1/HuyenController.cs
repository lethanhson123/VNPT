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
			BaseParameter baseParameter = new BaseParameter();
			List<Huyen> result = new List<Huyen>();
			Huyen itemResult = new Huyen();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _HuyenBusiness.GetSQLByNhanVienID_ActiveAsync(baseParameter.NhanVienID.Value);
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
			if (result == null)
			{
				result = new List<Huyen>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
	}
}
