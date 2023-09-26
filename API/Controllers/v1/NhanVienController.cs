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
    }
}
