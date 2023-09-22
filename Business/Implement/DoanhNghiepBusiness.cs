
namespace Business.Implement
{
    public class DoanhNghiepBusiness : BaseBusiness<DoanhNghiep, IDoanhNghiepRepository>, IDoanhNghiepBusiness
    {
        private readonly IDoanhNghiepRepository _DoanhNghiepRepository;
        public DoanhNghiepBusiness(IDoanhNghiepRepository DoanhNghiepRepository) : base(DoanhNghiepRepository)
        {
            _DoanhNghiepRepository = DoanhNghiepRepository;
        }
    }
}
