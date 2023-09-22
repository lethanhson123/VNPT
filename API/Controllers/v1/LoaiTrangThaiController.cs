namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class LoaiTrangThaiController : BaseController<LoaiTrangThai, ILoaiTrangThaiBusiness>
    {
        private readonly ILoaiTrangThaiBusiness _LoaiTrangThaiBusiness;
        public LoaiTrangThaiController(ILoaiTrangThaiBusiness LoaiTrangThaiBusiness) : base(LoaiTrangThaiBusiness)
        {
            _LoaiTrangThaiBusiness = LoaiTrangThaiBusiness;
        }
    }
}
