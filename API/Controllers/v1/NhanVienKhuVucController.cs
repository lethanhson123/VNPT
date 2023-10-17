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
            List<NhanVienKhuVuc> result = new List<NhanVienKhuVuc>();
            try
            {
                long parentID = JsonConvert.DeserializeObject<long>(Request.Form["parentID"]);                
                result = await _NhanVienKhuVucBusiness.GetSQLByParentIDAsync(parentID);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
            return result;
        }
    }
}
