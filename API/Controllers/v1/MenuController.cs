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
			List<Menu> result = new List<Menu>();
			try
			{
				long nhanVienID = JsonConvert.DeserializeObject<long>(Request.Form["data"]);
				result = await _MenuBusiness.GetByNhanVienIDToListAsync(nhanVienID);
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
			}
			return result;
		}
	}
}
