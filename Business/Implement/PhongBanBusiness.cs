
namespace Business.Implement
{
    public class PhongBanBusiness : BaseBusiness<PhongBan, IPhongBanRepository>, IPhongBanBusiness
    {
        private readonly IPhongBanRepository _PhongBanRepository;
        public PhongBanBusiness(IPhongBanRepository PhongBanRepository) : base(PhongBanRepository)
        {
            _PhongBanRepository = PhongBanRepository;
        }
    }
}
