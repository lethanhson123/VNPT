namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NhanVienController : BaseController<NhanVien, INhanVienBusiness>
    {
        private readonly INhanVienBusiness _NhanVienBusiness;
        public NhanVienController(INhanVienBusiness NhanVienBusiness) : base(NhanVienBusiness)
        {
            _NhanVienBusiness = NhanVienBusiness;
        }
        [HttpGet]
        [Route("GetByIDStringAsync")]
        public async Task<NhanVien> GetByIDStringAsync(string ID)
        {
            NhanVien result = new NhanVien();
            if (!string.IsNullOrEmpty(ID))
            {
                ID = GlobalHelper.InitializationURLCode(ID);
                result = await _NhanVienBusiness.GetByIDAsync(int.Parse(ID));
            }
            return result;
        }
    }
}
