
namespace Business.Implement
{
    public class DoanhNghiepDichVuBusiness : BaseBusiness<DoanhNghiepDichVu, IDoanhNghiepDichVuRepository>, IDoanhNghiepDichVuBusiness
    {
        private readonly IDoanhNghiepDichVuRepository _DoanhNghiepDichVuRepository;
        public DoanhNghiepDichVuBusiness(IDoanhNghiepDichVuRepository DoanhNghiepDichVuRepository) : base(DoanhNghiepDichVuRepository)
        {
            _DoanhNghiepDichVuRepository = DoanhNghiepDichVuRepository;
        }
    }
}
