
namespace Business.Implement
{
    public class HuyenBusiness : BaseBusiness<Huyen, IHuyenRepository>, IHuyenBusiness
    {
        private readonly IHuyenRepository _HuyenRepository;
        public HuyenBusiness(IHuyenRepository HuyenRepository) : base(HuyenRepository)
        {
            _HuyenRepository = HuyenRepository;
        }
    }
}
