
namespace Business.Implement
{
    public class DichVuBusiness : BaseBusiness<DichVu, IDichVuRepository>, IDichVuBusiness
    {
        private readonly IDichVuRepository _DichVuRepository;
        public DichVuBusiness(IDichVuRepository DichVuRepository) : base(DichVuRepository)
        {
            _DichVuRepository = DichVuRepository;
        }
    }
}
