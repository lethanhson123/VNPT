namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DoanhNghiepThanhVienController : BaseController<DoanhNghiepThanhVien, IDoanhNghiepThanhVienBusiness>
    {
        private readonly IDoanhNghiepThanhVienBusiness _DoanhNghiepThanhVienBusiness;
        public DoanhNghiepThanhVienController(IDoanhNghiepThanhVienBusiness DoanhNghiepThanhVienBusiness) : base(DoanhNghiepThanhVienBusiness)
        {
            _DoanhNghiepThanhVienBusiness = DoanhNghiepThanhVienBusiness;
        }
    }
}
