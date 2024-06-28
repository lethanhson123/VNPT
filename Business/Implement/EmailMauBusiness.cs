
namespace Business.Implement
{
    public class EmailMauBusiness : BaseBusiness<EmailMau, IEmailMauRepository>, IEmailMauBusiness
    {
        private readonly IEmailMauRepository _EmailMauRepository;
        public EmailMauBusiness(IEmailMauRepository EmailMauRepository) : base(EmailMauRepository)
        {
            _EmailMauRepository = EmailMauRepository;
        }
    }
}
