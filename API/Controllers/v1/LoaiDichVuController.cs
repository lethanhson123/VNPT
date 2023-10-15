namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class LoaiDichVuController : BaseController<LoaiDichVu, ILoaiDichVuBusiness>
    {
        private readonly ILoaiDichVuBusiness _LoaiDichVuBusiness;
        public LoaiDichVuController(ILoaiDichVuBusiness LoaiDichVuBusiness) : base(LoaiDichVuBusiness)
        {
            _LoaiDichVuBusiness = LoaiDichVuBusiness;
        }
    }
}
