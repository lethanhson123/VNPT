namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmailChienDichChiTietController : BaseController<EmailChienDichChiTiet, IEmailChienDichChiTietBusiness>
    {
        private readonly IEmailChienDichChiTietBusiness _EmailChienDichChiTietBusiness;
        public EmailChienDichChiTietController(IEmailChienDichChiTietBusiness EmailChienDichChiTietBusiness) : base(EmailChienDichChiTietBusiness)
        {
            _EmailChienDichChiTietBusiness = EmailChienDichChiTietBusiness;
        }
    }
}
