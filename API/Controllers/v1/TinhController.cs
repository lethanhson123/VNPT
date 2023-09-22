namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TinhController : BaseController<Tinh, ITinhBusiness>
    {
        private readonly ITinhBusiness _TinhBusiness;
        public TinhController(ITinhBusiness TinhBusiness) : base(TinhBusiness)
        {
            _TinhBusiness = TinhBusiness;
        }
    }
}
