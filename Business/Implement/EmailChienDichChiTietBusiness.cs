
namespace Business.Implement
{
    public class EmailChienDichChiTietBusiness : BaseBusiness<EmailChienDichChiTiet, IEmailChienDichChiTietRepository>, IEmailChienDichChiTietBusiness
    {
        private readonly IEmailChienDichChiTietRepository _EmailChienDichChiTietRepository;
        public EmailChienDichChiTietBusiness(IEmailChienDichChiTietRepository EmailChienDichChiTietRepository) : base(EmailChienDichChiTietRepository)
        {
            _EmailChienDichChiTietRepository = EmailChienDichChiTietRepository;
        }
    }
}
