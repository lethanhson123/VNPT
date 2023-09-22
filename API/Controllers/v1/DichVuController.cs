namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class DichVuController : BaseController<DichVu, IDichVuBusiness>
    {
        private readonly IDichVuBusiness _DichVuBusiness;
        public DichVuController(IDichVuBusiness DichVuBusiness) : base(DichVuBusiness)
        {
            _DichVuBusiness = DichVuBusiness;
        }
    }
}
