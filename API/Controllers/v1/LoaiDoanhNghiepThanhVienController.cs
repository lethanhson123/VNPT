namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class LoaiDoanhNghiepThanhVienController : BaseController<LoaiDoanhNghiepThanhVien, ILoaiDoanhNghiepThanhVienBusiness>
    {
        private readonly ILoaiDoanhNghiepThanhVienBusiness _LoaiDoanhNghiepThanhVienBusiness;
        public LoaiDoanhNghiepThanhVienController(ILoaiDoanhNghiepThanhVienBusiness LoaiDoanhNghiepThanhVienBusiness) : base(LoaiDoanhNghiepThanhVienBusiness)
        {
            _LoaiDoanhNghiepThanhVienBusiness = LoaiDoanhNghiepThanhVienBusiness;
        }
    }
}
