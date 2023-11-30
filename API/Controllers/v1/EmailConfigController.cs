namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class EmailConfigController : BaseController<EmailConfig, IEmailConfigBusiness>
    {
        private readonly IEmailConfigBusiness _EmailConfigBusiness;
        public EmailConfigController(IEmailConfigBusiness EmailConfigBusiness) : base(EmailConfigBusiness)
        {
            _EmailConfigBusiness = EmailConfigBusiness;
        }
    }
}
