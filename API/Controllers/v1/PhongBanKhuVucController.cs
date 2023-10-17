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
            List<PhongBanKhuVuc> result = new List<PhongBanKhuVuc>();
            try
            {
                long parentID = JsonConvert.DeserializeObject<long>(Request.Form["parentID"]);
                result = await _PhongBanKhuVucBusiness.GetSQLByParentIDAsync(parentID);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}
