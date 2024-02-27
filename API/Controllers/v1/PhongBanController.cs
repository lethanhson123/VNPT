namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PhongBanController : BaseController<PhongBan, IPhongBanBusiness>
    {
        private readonly IPhongBanBusiness _PhongBanBusiness;
        public PhongBanController(IPhongBanBusiness PhongBanBusiness) : base(PhongBanBusiness)
        {
            _PhongBanBusiness = PhongBanBusiness;
        }
        [HttpPost]
        [Route("GetByIDStringAsync")]
        public async Task<PhongBan> GetByIDStringAsync()
        {
			BaseParameter baseParameter = new BaseParameter();
			PhongBan result = new PhongBan();
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
						result = await _PhongBanBusiness.GetByIDAsync(baseParameter.ID);
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
    }
}
