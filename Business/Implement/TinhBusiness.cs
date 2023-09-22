
namespace Business.Implement
{
    public class TinhBusiness : BaseBusiness<Tinh, ITinhRepository>, ITinhBusiness
    {
        private readonly ITinhRepository _TinhRepository;
        public TinhBusiness(ITinhRepository TinhRepository) : base(TinhRepository)
        {
            _TinhRepository = TinhRepository;
        }
    }
}
