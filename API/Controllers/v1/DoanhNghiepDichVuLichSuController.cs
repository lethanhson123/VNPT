namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DoanhNghiepDichVuLichSuController : BaseController<DoanhNghiepDichVuLichSu, IDoanhNghiepDichVuLichSuBusiness>
    {
        private readonly IDoanhNghiepDichVuLichSuBusiness _DoanhNghiepDichVuLichSuBusiness;
        public DoanhNghiepDichVuLichSuController(IDoanhNghiepDichVuLichSuBusiness DoanhNghiepDichVuLichSuBusiness) : base(DoanhNghiepDichVuLichSuBusiness)
        {
            _DoanhNghiepDichVuLichSuBusiness = DoanhNghiepDichVuLichSuBusiness;
        }
    }
}
