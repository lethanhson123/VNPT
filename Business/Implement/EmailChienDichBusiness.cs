
namespace Business.Implement
{
    public class EmailChienDichBusiness : BaseBusiness<EmailChienDich, IEmailChienDichRepository>, IEmailChienDichBusiness
    {
        private readonly IEmailChienDichRepository _EmailChienDichRepository;
        public EmailChienDichBusiness(IEmailChienDichRepository EmailChienDichRepository) : base(EmailChienDichRepository)
        {
            _EmailChienDichRepository = EmailChienDichRepository;
        }
    }
}
