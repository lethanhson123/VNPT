namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmailChienDichController : BaseController<EmailChienDich, IEmailChienDichBusiness>
    {
        private readonly IEmailChienDichBusiness _EmailChienDichBusiness;
        public EmailChienDichController(IEmailChienDichBusiness EmailChienDichBusiness) : base(EmailChienDichBusiness)
        {
            _EmailChienDichBusiness = EmailChienDichBusiness;
        }
    }
}
