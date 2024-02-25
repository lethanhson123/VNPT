namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NhanVienChucNangController : BaseController<NhanVienChucNang, INhanVienChucNangBusiness>
    {
        private readonly INhanVienChucNangBusiness _NhanVienChucNangBusiness;
        public NhanVienChucNangController(INhanVienChucNangBusiness NhanVienChucNangBusiness) : base(NhanVienChucNangBusiness)
        {
            _NhanVienChucNangBusiness = NhanVienChucNangBusiness;
        }
    }
}
