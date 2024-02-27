namespace API.Controllers.v1
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class MenuController : BaseController<Menu, IMenuBusiness>
	{
		private readonly IMenuBusiness _MenuBusiness;
		public MenuController(IMenuBusiness MenuBusiness) : base(MenuBusiness)
		{
			_MenuBusiness = MenuBusiness;
		}
		[HttpPost]
		[Route("GetByNhanVienIDToListAsync")]
		public virtual async Task<List<Menu>> GetByNhanVienIDToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Menu> result = new List<Menu>();
			Menu itemResult = new Menu();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _MenuBusiness.GetByNhanVienIDToListAsync(baseParameter.NhanVienID.Value);
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
				result = new List<Menu>();
			}
			if (result.Count == 0)
			{
				itemResult.Description = baseParameter.APIMessage;
				result.Add(itemResult);
			}
			return result;
		}
		[HttpPost]
		[Route("GetSQLByNhanVienIDAndActiveToListAsync")]
		public virtual async Task<List<Menu>> GetSQLByNhanVienIDAndActiveToListAsync()
		{
			BaseParameter baseParameter = new BaseParameter();
			List<Menu> result = new List<Menu>();
			Menu itemResult = new Menu();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _MenuBusiness.GetSQLByNhanVienIDAndActiveToListAsync(baseParameter.NhanVienID.Value, baseParameter.Active.Value);
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
				result = new List<Menu>();
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
