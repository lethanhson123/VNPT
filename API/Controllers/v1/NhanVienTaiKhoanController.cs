namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NhanVienTaiKhoanController : BaseController<NhanVienTaiKhoan, INhanVienTaiKhoanBusiness>
    {
        private readonly INhanVienTaiKhoanBusiness _NhanVienTaiKhoanBusiness;
        public NhanVienTaiKhoanController(INhanVienTaiKhoanBusiness NhanVienTaiKhoanBusiness) : base(NhanVienTaiKhoanBusiness)
        {
            _NhanVienTaiKhoanBusiness = NhanVienTaiKhoanBusiness;
        }
    }
}
