namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DoanhNghiepController : BaseController<DoanhNghiep, IDoanhNghiepBusiness>
    {
        private readonly IDoanhNghiepBusiness _DoanhNghiepBusiness;
        public DoanhNghiepController(IDoanhNghiepBusiness DoanhNghiepBusiness) : base(DoanhNghiepBusiness)
        {
            _DoanhNghiepBusiness = DoanhNghiepBusiness;
        }
    }
}
