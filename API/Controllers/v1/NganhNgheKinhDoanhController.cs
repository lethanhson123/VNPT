namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class NganhNgheKinhDoanhController : BaseController<NganhNgheKinhDoanh, INganhNgheKinhDoanhBusiness>
    {
        private readonly INganhNgheKinhDoanhBusiness _NganhNgheKinhDoanhBusiness;
        public NganhNgheKinhDoanhController(INganhNgheKinhDoanhBusiness NganhNgheKinhDoanhBusiness) : base(NganhNgheKinhDoanhBusiness)
        {
            _NganhNgheKinhDoanhBusiness = NganhNgheKinhDoanhBusiness;
        }
    }
}
