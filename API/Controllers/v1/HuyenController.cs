namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class HuyenController : BaseController<Huyen, IHuyenBusiness>
    {
        private readonly IHuyenBusiness _HuyenBusiness;
        public HuyenController(IHuyenBusiness HuyenBusiness) : base(HuyenBusiness)
        {
            _HuyenBusiness = HuyenBusiness;
        }
    }
}
