namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class LoaiDoanhNghiepController : BaseController<LoaiDoanhNghiep, ILoaiDoanhNghiepBusiness>
    {
        private readonly ILoaiDoanhNghiepBusiness _LoaiDoanhNghiepBusiness;
        public LoaiDoanhNghiepController(ILoaiDoanhNghiepBusiness LoaiDoanhNghiepBusiness) : base(LoaiDoanhNghiepBusiness)
        {
            _LoaiDoanhNghiepBusiness = LoaiDoanhNghiepBusiness;
        }
    }
}
