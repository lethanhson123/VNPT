
namespace Business.Implement
{
    public class EmailConfigBusiness : BaseBusiness<EmailConfig, IEmailConfigRepository>, IEmailConfigBusiness
    {
        private readonly IEmailConfigRepository _EmailConfigRepository;
        public EmailConfigBusiness(IEmailConfigRepository EmailConfigRepository) : base(EmailConfigRepository)
        {
            _EmailConfigRepository = EmailConfigRepository;
        }
    }
}
