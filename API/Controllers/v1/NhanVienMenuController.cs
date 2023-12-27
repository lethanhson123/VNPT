namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NhanVienMenuController : BaseController<NhanVienMenu, INhanVienMenuBusiness>
    {
        private readonly INhanVienMenuBusiness _NhanVienMenuBusiness;
        public NhanVienMenuController(INhanVienMenuBusiness NhanVienMenuBusiness) : base(NhanVienMenuBusiness)
        {
            _NhanVienMenuBusiness = NhanVienMenuBusiness;
        }
    }
}
