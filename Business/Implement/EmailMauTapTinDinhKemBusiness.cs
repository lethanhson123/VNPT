
namespace Business.Implement
{
    public class EmailMauTapTinDinhKemBusiness : BaseBusiness<EmailMauTapTinDinhKem, IEmailMauTapTinDinhKemRepository>, IEmailMauTapTinDinhKemBusiness
    {
        private readonly IEmailMauTapTinDinhKemRepository _EmailMauTapTinDinhKemRepository;
        public EmailMauTapTinDinhKemBusiness(IEmailMauTapTinDinhKemRepository EmailMauTapTinDinhKemRepository) : base(EmailMauTapTinDinhKemRepository)
        {
            _EmailMauTapTinDinhKemRepository = EmailMauTapTinDinhKemRepository;
        }
    }
}
