namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PhongBanController : BaseController<PhongBan, IPhongBanBusiness>
    {
        private readonly IPhongBanBusiness _PhongBanBusiness;
        public PhongBanController(IPhongBanBusiness PhongBanBusiness) : base(PhongBanBusiness)
        {
            _PhongBanBusiness = PhongBanBusiness;
        }
    }
}
