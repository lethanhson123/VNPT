namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DoanhNghiepDichVuCAController : BaseController<DoanhNghiepDichVuCA, IDoanhNghiepDichVuCABusiness>
    {
        private readonly IDoanhNghiepDichVuCABusiness _DoanhNghiepDichVuCABusiness;
        public DoanhNghiepDichVuCAController(IDoanhNghiepDichVuCABusiness DoanhNghiepDichVuCABusiness) : base(DoanhNghiepDichVuCABusiness)
        {
            _DoanhNghiepDichVuCABusiness = DoanhNghiepDichVuCABusiness;
        }
    }
}
