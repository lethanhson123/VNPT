namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class XaController : BaseController<Xa, IXaBusiness>
    {
        private readonly IXaBusiness _XaBusiness;
        public XaController(IXaBusiness XaBusiness) : base(XaBusiness)
        {
            _XaBusiness = XaBusiness;
        }
    }
}
