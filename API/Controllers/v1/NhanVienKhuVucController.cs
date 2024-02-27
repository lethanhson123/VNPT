namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NhanVienKhuVucController : BaseController<NhanVienKhuVuc, INhanVienKhuVucBusiness>
    {
        private readonly INhanVienKhuVucBusiness _NhanVienKhuVucBusiness;
        public NhanVienKhuVucController(INhanVienKhuVucBusiness NhanVienKhuVucBusiness) : base(NhanVienKhuVucBusiness)
        {
            _NhanVienKhuVucBusiness = NhanVienKhuVucBusiness;
        }
        [HttpPost]
        [Route("GetSQLByParentIDAsync")]
        public virtual async Task<List<NhanVienKhuVuc>> GetSQLByParentIDAsync()
        {
			BaseParameter baseParameter = new BaseParameter();
			List<NhanVienKhuVuc> result = new List<NhanVienKhuVuc>();
			NhanVienKhuVuc itemResult = new NhanVienKhuVuc();
			try
			{
				baseParameter = JsonConvert.DeserializeObject<BaseParameter>(Request.Form["data"]);
				if (baseParameter.Token == GlobalHelper.Token)
				{
					baseParameter.APIMessage = GlobalHelper.APISuccessMessage;
					result = await _NhanVienKhuVucBusiness.GetSQLByParentIDAsync(baseParameter.ParentID.Value);
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
				result = new List<NhanVienKhuVuc>();
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
