namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PhongBanKhuVucController : BaseController<PhongBanKhuVuc, IPhongBanKhuVucBusiness>
    {
        private readonly IPhongBanKhuVucBusiness _PhongBanKhuVucBusiness;
        public PhongBanKhuVucController(IPhongBanKhuVucBusiness PhongBanKhuVucBusiness) : base(PhongBanKhuVucBusiness)
        {
            _PhongBanKhuVucBusiness = PhongBanKhuVucBusiness;
        }
        [HttpPost]
        [Route("GetSQLByParentIDAsync")]
        public virtual async Task<List<PhongBanKhuVuc>> GetSQLByParentIDAsync()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<PhongBanKhuVuc> result = new List<PhongBanKhuVuc>();
			PhongBanKhuVuc itemResult = new PhongBanKhuVuc();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _PhongBanKhuVucBusiness.GetSQLByParentIDAsync(baseParameter.ParentID.Value);
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
				result = new List<PhongBanKhuVuc>();
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
