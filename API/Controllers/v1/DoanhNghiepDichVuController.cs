namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DoanhNghiepDichVuController : BaseController<DoanhNghiepDichVu, IDoanhNghiepDichVuBusiness>
    {
        private readonly IDoanhNghiepDichVuBusiness _DoanhNghiepDichVuBusiness;
        public DoanhNghiepDichVuController(IDoanhNghiepDichVuBusiness DoanhNghiepDichVuBusiness) : base(DoanhNghiepDichVuBusiness)
        {
            _DoanhNghiepDichVuBusiness = DoanhNghiepDichVuBusiness;
        }
    }
}
